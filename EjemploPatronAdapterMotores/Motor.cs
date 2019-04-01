using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploPatronAdapterMotores
{
    public abstract class Motor
    {
        abstract public void Encender();
        abstract public void Acelerar();
        abstract public void Apagar();
    }
}
