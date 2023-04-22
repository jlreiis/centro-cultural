using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RelicarioApplication.Models
{
    public class EnderecoModel
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        [JsonIgnore]
        public AlunoModel Aluno { get; set; }

        public int AlunoId { get; set; }
    }
}
