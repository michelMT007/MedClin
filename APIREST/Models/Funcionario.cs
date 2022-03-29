using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIREST.Models
{
    public class Funcionario : Pessoa
    {
        public int matricula { get; set; }
        public string profissao { get; set; }
        public bool Ativo { get; set; }
    }
}
