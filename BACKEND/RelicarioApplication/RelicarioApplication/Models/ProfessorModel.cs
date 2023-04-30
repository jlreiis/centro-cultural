using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RelicarioApplication.Models
{
    public class ProfessorModel //User
    {
        [Key]
        public int Id { get; set; }
        public string NomeProfessor { get; set; }
        public string AtvResponsavel { get; set; }
        public DateTime DtEntrada { get; set; }
        public List<AlunoModel>Alunos { get; set; }
    }
}
