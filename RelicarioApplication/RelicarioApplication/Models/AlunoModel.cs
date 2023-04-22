using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RelicarioApplication.Models
{
    public class AlunoModel
    {
      
        public int Id { get; set; }

        /*[JsonIgnore]
        public ProfessorModel Professor { get; set; }*/
        //public int ProfessorId { get; set; }
        public string NomeAluno { get; set; } = String.Empty;
        public int Idade { get; set; }
        public string NomeResponsavel { get; set; } = String.Empty;        
        public string RG { get; set; } = String.Empty;
        public string CPF { get; set; } = String.Empty;
        public DateTime DtEntrada { get; set; }

        //Aluno e Professor tem uma relçao que é feita da seguinte forma
        
        /*public EnderecoModel Endereco { get; set; }
        public List<AtividadeModel> Atividades { get; set; }*/

    }
}
