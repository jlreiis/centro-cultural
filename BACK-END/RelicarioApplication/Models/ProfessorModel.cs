using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelicarioApplication.Models
{
    public class ProfessorModel
    {
        public int Id { get; set; }
        public string NomeProfessor { get; set; } = String.Empty;
        
        //Professor traz uma lista de alunos
        public List<AlunoModel>Alunos { get; set; }
    }
}
