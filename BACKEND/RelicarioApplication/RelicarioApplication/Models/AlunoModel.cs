using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RelicarioApplication.Models
{
    public class AlunoModel //Character
    {
        [Key]
        public int Id { get; set; }   
        public string NomeAluno { get; set; } = String.Empty;
        public int Idade { get; set; }
        public string NomeResponsavel { get; set; } = String.Empty;        
        public string RG { get; set; } = String.Empty;
        public string CPF { get; set; } = String.Empty;
        public DateTime DtEntrada { get; set; }

        [JsonIgnore]
        public ProfessorModel Professor { get; set; }
        public int ProfessorId { get; set; }
    }
}
