using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MiModeloMVC.Models
{
    public class Clientes
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string nombre { get; set; }

        [Display (Name = "Fecha de alta")]
        [DataType (DataType.Date)]
        [DisplayFormat (DataFormatString = "{0:dd-MM-YYYY}", ApplyFormatInEditMode = true)]
        public DateTime FechaAlta { get; set; }

        [Range (18, 75)]
        public int edad { get; set; }
    }

    public class EmpDBContext : DbContext
    {
        public EmpDBContext()
        {

        }

        public DbSet<Clientes> Clientes { get; set; }
    }
}