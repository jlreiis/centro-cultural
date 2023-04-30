using Microsoft.EntityFrameworkCore;
using RelicarioApplication.Data;
using RelicarioApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelicarioApplication.Repository
{
    public class ProfessorRepo : IProfessorRepo
    {
        private readonly ApplicationContext _context;
        public ProfessorRepo(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProfessorModel>> GetProfessores()
        {
            return await _context.TB_PROFESSORES.ToListAsync();
        }
        public async Task<ProfessorModel> GetProfessorById(int id)
        {
            var professor = await _context.TB_PROFESSORES.FindAsync(id);
            return professor;
        }
       
        public async Task CreateProfessor(ProfessorModel professor)
        {
            _context.TB_PROFESSORES.Add(professor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProfessor(ProfessorModel professor)
        {
            _context.Entry(professor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteProfessor(ProfessorModel professor)
        {
            _context.TB_PROFESSORES.Remove(professor);
            await _context.SaveChangesAsync();
        }

    
    }
}
