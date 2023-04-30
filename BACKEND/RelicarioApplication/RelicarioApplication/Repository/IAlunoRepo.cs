using RelicarioApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelicarioApplication.Repository
{
    public interface IAlunoRepo
    {
        Task<IEnumerable<AlunoModel>> GetAlunos();
        Task<AlunoModel> GetAluno(int id);
        //Task<IEnumerable<AlunoModel>> GetAlunoByNome(string nome);
        Task CreateAluno(AlunoModel aluno);
        Task UpdateAluno(AlunoModel aluno);
        Task DeleteAluno(AlunoModel aluno);
    }
}
