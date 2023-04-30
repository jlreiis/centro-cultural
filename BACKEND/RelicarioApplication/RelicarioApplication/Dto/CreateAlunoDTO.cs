using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelicarioApplication.Dto
{
    public class CreateAlunoDTO
    {
        public string NomeAluno { get; set; } = String.Empty;
        public int Idade { get; set; }
        public string NomeResponsavel { get; set; } = String.Empty;
        public string RG { get; set; } = String.Empty;
        public string CPF { get; set; } = String.Empty;
        public DateTime DtEntrada { get; set; }
        public int ProfessorId { get; set; } = 1;


    }
}
