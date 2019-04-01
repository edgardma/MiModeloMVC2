using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploPatronAdapterMotores
{
    public class MotorComun : Motor
    {
        public MotorComun() : base()
        {
            Console.WriteLine("Creando el Motor Comun");
        }

        public override void Acelerar()
        {
            Console.WriteLine("Acelerando Motor Comun");
        }

        public override void Apagar()
        {
            Console.WriteLine("Apagando Motor Comun");
        }

        public override void Encender()
        {
            Console.WriteLine("Encendiendo Motor Comun");
        }
    }
}
