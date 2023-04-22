using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RelicarioApplication.Models
{
    public class AtividadeModel
    {
        public int Id { get; set; }
        public string NomeAtividade { get; set; }
        
        //Lista de persongens que realizarm essa atividade
        [JsonIgnore]
        public List<AlunoModel>Alunos { get; set; }
    }
}
