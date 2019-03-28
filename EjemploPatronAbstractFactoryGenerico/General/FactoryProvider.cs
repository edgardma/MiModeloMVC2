using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploPatronAbstractFactoryGenerico.General
{
    public class FactoryProvider
    {
        public static IAbstractFactory<T> GetFactory<T>(String choice)
        {
            if ("Animal".Equals(choice))
            {
                return new Animals.AnimalFactory();
            }

            return null;
        }
    }
}
