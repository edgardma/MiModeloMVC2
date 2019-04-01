using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploPatronAdapterMotores
{
    public class MotorElectrico
    {
        private bool conectado = false;

        public MotorElectrico()
        {
            Console.WriteLine("Creando Motor Electrico");
            this.conectado = false;
        }

        public void Conectar()
        {
            Console.WriteLine("Conectado Motor Electrico");
            this.conectado = true;
        }

        public void Activar()
        {
            if (!this.conectado)
            {
                Console.WriteLine("No se puede activar porque no esta conectado el Motor Electrico");
            }
            else
            {
                Console.WriteLine("Esta conectado, activando motor electrico...");
            }
        }

        public void MoverMasRapido()
        {
            if (!this.conectado)
            {
                Console.WriteLine("No se puede mover rapido porque no esta conectado el Motor Electrico");
            }
            else
            {
                Console.WriteLine("Moviendo mas rapido, aumentado voltaje el motor electrico...");
            }
        }

        public void Detener()
        {
            if (!this.conectado)
            {
                Console.WriteLine("No se puede detener porque no esta conectado el Motor Electrico");
            }
            else
            {
                Console.WriteLine("Deteniendo el motor electrico");
            }
        }

        public void Desconectar()
        {
            Console.WriteLine("Desconectando Motor Electrico");
            this.conectado = false;
        }
    }
}
