using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace MiScaffoldingMVC.Models
{
    public class Clientes
    {
        public int ID { get; set; }

        public string nombre { get; set; }

        public DateTime FechaAlta { get; set; }

        public int edad { get; set; }
    }

    public class EmpDBContext : DbContext
    {
        //DbSet<Clientes> Clientes { get; set; }

        public System.Data.Entity.DbSet<MiScaffoldingMVC.Models.Clientes> Clientes { get; set; }
    }
}