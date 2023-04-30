using RelicarioApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelicarioApplication.Repository
{
    public interface IProfessorRepo
    {
        Task<IEnumerable<ProfessorModel>> GetProfessores();
        Task<ProfessorModel> GetProfessorById(int id);
        Task CreateProfessor(ProfessorModel professor);
        Task UpdateProfessor(ProfessorModel professor);
        Task DeleteProfessor(ProfessorModel professor);
    }
}
