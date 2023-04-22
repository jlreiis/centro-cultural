using Microsoft.AspNetCore.Mvc;
using RelicarioApplication.Models;
using RelicarioApplication.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RelicarioApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepo _alunoRepo;
        public AlunoController(IAlunoRepo alunoRepo)
        {
            _alunoRepo = alunoRepo;
        }
        [HttpGet("todosalunos")]
        public async Task<ActionResult<IEnumerable<AlunoModel>>> GetTodosAlunosCadastrados()
        {
            try
            {
                var alunos = await _alunoRepo.GetAlunos();
                return Ok(alunos);
            }
            catch (System.Exception)
            {
                
                return BadRequest("Aluno não encontrado");
            }
        }
        [HttpGet("{id:int}", Name = "GetAluno")]
        public async Task<ActionResult<AlunoModel>> GetAluno(int id)
        {
            try
            {
                var aluno = await _alunoRepo.GetAluno(id);

                if (aluno == null)
                
                    return BadRequest("Aluno não encontrado");
                
                return Ok(aluno);
            }
            catch 
            {

                return BadRequest("Aluno não encontrado");
            }

        }

        [HttpPost]
        public async Task<ActionResult> CreateAluno([FromBody] AlunoModel aluno)
        {
            try
            {
                await _alunoRepo.CreateAluno(aluno);
                
                return CreatedAtRoute(nameof(GetAluno), new { id = aluno.Id }, aluno);

            }
            catch (System.Exception)
            {
                return BadRequest("Aluno não cadastrado");
            }
        }   
        [HttpPut]
        public async Task<ActionResult>EditAluno([FromBody] AlunoModel aluno, int id)
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
        public async Task<ActionResult>DeleteAluno(int id)
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
