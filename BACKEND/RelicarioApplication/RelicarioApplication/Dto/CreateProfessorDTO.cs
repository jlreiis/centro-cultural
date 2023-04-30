using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RelicarioApplication.Dto
{
    public class CreateProfessorDTO
    {
        public int ProfessorId { get; set; } = 1;
        public string NomeProfessor { get; set; }
        public string AtvResponsavel { get; set; }
        public DateTime DtEntrada { get; set; }

    }
}
