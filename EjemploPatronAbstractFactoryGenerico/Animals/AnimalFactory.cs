using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploPatronAbstractFactoryGenerico.Animals
{
    public class AnimalFactory : General.IAbstractFactory<IAnimal>
    {
        public IAnimal Create(string type)
        {
            if ("Dog".Equals(type))
            {
                return new Dog();
            }
            else if ("Duck".Equals(type))
            {
                return new Duck();
            }

            return null;
        }
    }
}
