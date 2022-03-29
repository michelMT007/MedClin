using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIREST.Models
{
    public class Paciente : Pessoa
    {
        public string Prontoario { get; set; }
        public string Observacao { get; set; }
    }
}
