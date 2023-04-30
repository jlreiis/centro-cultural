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
    [Route("api/")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IProfessorRepo _professorRepo;

        public ProfessorController(ApplicationContext context, IProfessorRepo professorRepo)
        {
            _context = context;
            _professorRepo = professorRepo;
        }
        [HttpGet("TodosProfessores")]
        public async Task<ActionResult<List<ProfessorModel>>> GetAllProfessores()
        {
            var professores = await _context.TB_PROFESSORES
             .Include(x => x.Alunos)
             .ToListAsync();

            return professores;
        }
        [HttpGet("Professor/Id")]
        public async Task<ActionResult<List<ProfessorModel>>> GetProfessorPorId(int professorId)
        {
            var professores = await _context.TB_PROFESSORES
                .Where (x => x.Id == professorId)
                .Include(x => x.Alunos)
                .ToListAsync();

            return professores;
        }

        [HttpPost]
        public async Task<ActionResult<List<AlunoModel>>> CreateProfessor(CreateProfessorDTO request)
        {
            var professor = await _context.TB_PROFESSORES.FindAsync(request.ProfessorId);
            if (professor == null)

                return NotFound("Professor não encontrado na base de dados");
            var newProfessor = new ProfessorModel
            {
                NomeProfessor = request.NomeProfessor,
                AtvResponsavel = request.AtvResponsavel,              
                DtEntrada = request.DtEntrada,
                
              
            };
            _context.TB_PROFESSORES.Add(newProfessor);
            await _context.SaveChangesAsync();
            return Ok("Professor cadastrado com sucesso");
        }

        [HttpPut]
        public async Task<ActionResult> EditProfessor([FromBody] ProfessorModel professor, int id)
        {
            try
            {
                if (professor.Id == id)
                {
                    await _professorRepo.UpdateProfessor(professor);
                    return Ok("Professor foi atualizado com sucesso.");
                   
                }
                else
                {
                    return BadRequest("Não foi possível editar esse professor");
                }
            }
            catch (System.Exception)
            {
                return BadRequest("REQUEST INVALIDO");
            }
        }
        
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteProfessor(int id)
        {
            try
            {
                var professor = await _professorRepo.GetProfessorById(id);

                if (professor != null)
                {
                    await _professorRepo.DeleteProfessor(professor);
                    return Ok("Professor foi deletado com sucesso");
                }

                else
                {
                    return NotFound("Professor não encontrado");
                }
            }
            catch
            {

                return BadRequest("Request invalido");
            }
        }
    }
}
    
