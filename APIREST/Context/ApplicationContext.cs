using APIREST.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIREST.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options)
        : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {  
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=univag;Integrated Security=True;Connect Timeout=30;Encrypt=False;" +
            "TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            //optionsBuilder.UseSqlServer("Data Source=192.168.160.17, 1433; Network Library=DBMSSOCN; Initial Catalog= DBSisCli; User ID=UsrSistema;Password=univ@g" "TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            /* Data Source=190.190.200.100,1433;Network Library=DBMSSOCN;Initial Catalog=myDataBase;User ID=myUsername;Password=myPassword; */
        }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<Procedimento> Procedimentos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }

    }
}
