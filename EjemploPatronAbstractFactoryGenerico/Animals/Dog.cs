using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploPatronAbstractFactoryGenerico.Animals
{
    public class Dog : IAnimal
    {
        public string GetAnimal()
        {
            return "Dog";
        }

        public string MakeSound()
        {
            return "Whua, whua";
        }
    }
}
