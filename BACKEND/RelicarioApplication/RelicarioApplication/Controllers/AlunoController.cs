using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RelicarioApplication.Data;
using RelicarioApplication.Dto;
using RelicarioApplication.Models;
using RelicarioApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelicarioApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IAlunoRepo _alunoRepo;

        public AlunoController(ApplicationContext context, IAlunoRepo alunoRepo)
        {
            _context = context;
            _alunoRepo = alunoRepo;
        }
        [HttpGet]
        public async Task<ActionResult<List<AlunoModel>>> GetAluno(int alunoId)
        {
            var alunos = await _context.TB_ALUNOS
             .Where(x => x.Id == alunoId)
             .ToListAsync();

            return alunos;
        }
        [HttpGet("todosalunos")]
        public async Task<ActionResult<List<AlunoModel>>> GetAllAlunos()
        {
            var alunos = await _context.TB_ALUNOS             
             .ToListAsync();

            return alunos;
        }

        [HttpPost]
        public async Task<ActionResult<List<AlunoModel>>> CreateAluno(CreateAlunoDTO request)
        {
            var professor = await _context.TB_PROFESSORES.FindAsync(request.ProfessorId);
            if (professor == null)

                return NotFound("Professor não encontrado na base de dados");
            var newAluno = new AlunoModel
            {
                NomeAluno = request.NomeAluno,
                Idade = request.Idade,
                NomeResponsavel = request.NomeResponsavel,
                RG = request.RG,
                CPF = request.CPF,
                DtEntrada = request.DtEntrada,
                Professor = professor
            };
            _context.TB_ALUNOS.Add(newAluno);
            await _context.SaveChangesAsync();
            return await GetAluno(professor.Id);
        }

        [HttpPut]
        public async Task<ActionResult> EditAluno([FromBody] AlunoModel aluno, int id)
        {
            try
            {
                if (aluno.Id == id)
                {

                    await _alunoRepo.UpdateAluno(aluno);
                    return Ok("Aluno foi atualizado com sucesso.");
                }
                else
                {
                    return BadRequest("Não foi possível editar esse aluno");
                }
            }
            catch (System.Exception)
            {
                return BadRequest("REQUEST INVALIDO");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAluno(int id)
        {
            try
            {
                var aluno = await _alunoRepo.GetAluno(id);

                if (aluno != null)
                {
                    await _alunoRepo.DeleteAluno(aluno);
                    return Ok("Aluno foi deletado com sucesso");
                }

                else
                {
                    return NotFound("Aluno não encontrado");
                }
            }
            catch
            {

                return BadRequest("Request invalido");
            }
        }
    }
}
    
