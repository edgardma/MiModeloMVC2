using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EjemploPatronAbstractFactoryCar.Factorys;

namespace EjemploPatronAbstractFactoryCar
{
    class Program
    {
        static void Main(string[] args)
        {
            CarClientAbstractFactory hondaClient;
            CarClientAbstractFactory toyotaClient;
            Console.WriteLine("\r\n------------This is HONDA Car Factory----------------");
            hondaClient = new CarClientAbstractFactory(new HondaFactory(), "compact");
            Console.WriteLine("\r\n Manufactureing " + hondaClient.GetManufacturedSedanName() + " as compact Sedan");
            Console.WriteLine("\r\n Manufactureing " + hondaClient.GetManufacturedSuvName() + " as compact SUV");

            hondaClient = new CarClientAbstractFactory(new HondaFactory(), "full");
            Console.WriteLine("\r\n Manufactureing " + hondaClient.GetManufacturedSedanName() + " as full Sedan");
            Console.WriteLine("\r\n Manufactureing " + hondaClient.GetManufacturedSuvName() + " as full SUV");

            Console.WriteLine("\r\n\r\n------------This is TOYOTA Car Factory----------------");
            toyotaClient = new CarClientAbstractFactory(new ToyotaFactory(), "compact");
            Console.WriteLine("\r\n Manufactureing " + toyotaClient.GetManufacturedSedanName() + " as compact Sedan");
            Console.WriteLine("\r\n Manufactureing " + toyotaClient.GetManufacturedSuvName() + " as compact SUV");

            toyotaClient = new CarClientAbstractFactory(new ToyotaFactory(), "full");
            Console.WriteLine("\r\n Manufactureing " + toyotaClient.GetManufacturedSedanName() + " as full Sedan");
            Console.WriteLine("\r\n Manufactureing " + toyotaClient.GetManufacturedSuvName() + " as full SUV");
            Console.ReadLine();
        }
    }
}
