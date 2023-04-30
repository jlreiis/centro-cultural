using Microsoft.EntityFrameworkCore;
using RelicarioApplication.Data;
using RelicarioApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelicarioApplication.Repository
{
    public class AlunoRepo : IAlunoRepo
    {
        private readonly ApplicationContext _context;
        public AlunoRepo(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<AlunoModel>> GetAlunos()
        {
            return await _context.TB_ALUNOS.ToListAsync();
        }
        public async Task<AlunoModel> GetAluno(int id)
        {
            var aluno = await _context.TB_ALUNOS.FindAsync(id);
            return aluno;
        }
        public async Task CreateAluno(AlunoModel aluno)
        {
            _context.TB_ALUNOS.Add(aluno);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAluno(AlunoModel aluno)
        {
            _context.Entry(aluno).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
        public async Task DeleteAluno(AlunoModel aluno)
        {
            _context.TB_ALUNOS.Remove(aluno);
            await _context.SaveChangesAsync();
        }

        /*public Task<IEnumerable<AlunoModel>> GetAlunoByNome(string nome)
        {
            throw new NotImplementedException();
        }*/
    }
}
