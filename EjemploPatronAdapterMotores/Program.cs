using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploPatronAdapterMotores
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===========================================");
            Motores.UsarMotorComun();
            Console.WriteLine("===========================================");
            Motores.UsarMotorEconomico();
            Console.WriteLine("===========================================");
            Motores.UsarMotorElectrico();
            Console.WriteLine("===========================================");
            Console.ReadKey();
        }
    }
}
