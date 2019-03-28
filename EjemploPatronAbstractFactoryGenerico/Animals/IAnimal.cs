using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploPatronAbstractFactoryGenerico.Animals
{
    public interface IAnimal
    {
        String GetAnimal();

        String MakeSound();
    }
}
