using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace APIREST.Models
{
    public class Atendimento
    {
        public int Id { get; set; }
        public DateTime DataAtendimento { get; set; }
        public int IdMedico { get; set; }
        public string NomeMedico { get; set; }
        public int IdAtendente { get; set; }
        public string NomeAtend { get; set; }
        public int IdProcedimentoMedico { get; set; }
        public string DescricaoProcedmento { get; set; }
        public int IdPacienteAtendido { get; set; }
        public string NomePaciente { get; set; }
        public decimal ValorProcedimento { get; set; }
        
        /*public Atendimento(int IdAtendente, int IdMedico, int IdProcedimento, int IdPaciente, DateTime DataAgenda) {
            
            this.IdPacienteAtendido = IdPaciente;
            this.IdAtendente = IdAtendente;
            this.IdMedico = IdMedico;
            this.IdProcedimentoMedico= IdProcedimento;
            this.DataAtendimento = DateTime.Now;
            this.DataAgenda = DataAgenda;
        }*/
        public Atendimento() {

           var dt = DateTime.Parse(DateTime.Now.ToString()).ToString("dd-MM-yyyy HH:mm:ss");
            DataAtendimento = DateTime.Parse(dt);
        }
    }
}

