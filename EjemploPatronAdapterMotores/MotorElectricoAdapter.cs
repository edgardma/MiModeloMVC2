using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploPatronAdapterMotores
{
    public class MotorElectricoAdapter : Motor
    {
        private readonly MotorElectrico motorElectrico;

        public MotorElectricoAdapter() : base()
        {
            this.motorElectrico = new MotorElectrico();
            Console.WriteLine("Creando el Motor Electrico Adapter");
        }

        public override void Acelerar()
        {
            Console.WriteLine("Acelerando el Motor Electrico Adapter");
            this.motorElectrico.MoverMasRapido();

        }

        public override void Apagar()
        {
            Console.WriteLine("Apagando el Motor Electrico Adapter");
            this.motorElectrico.Detener();
            this.motorElectrico.Desconectar();
        }

        public override void Encender()
        {
            Console.WriteLine("Encendiendo el Motor Electrico Adapter");
            this.motorElectrico.Conectar();
            this.motorElectrico.Activar();
        }
    }
}
