using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploPatronAdapterMotores
{
    public class MotorEconomico : Motor
    {
        public MotorEconomico() : base()
        {
            Console.WriteLine("Creando el Motor Economico");
        }

        public override void Acelerar()
        {
            Console.WriteLine("Acelerando Motor Economico");
        }

        public override void Apagar()
        {
            Console.WriteLine("Apagando Motor Economico");
        }

        public override void Encender()
        {
            Console.WriteLine("Encendiendo Motor Economico");
        }
    }
}
