using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploPatronAbstractFactoryGenerico.Animals
{
    public class Duck : IAnimal
    {
        public string GetAnimal()
        {
            return "Duck";
        }

        public string MakeSound()
        {
            return "Squeks";
        }
    }
}
