using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploPatronAbstractFactoryGenerico.General
{
    public interface IAbstractFactory<T>
    {
        T Create(String type);
    }
}
