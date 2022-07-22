using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIREST.Models
{
    public class Procedimento
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Decimal Valor{ get; set; }
    }
}
