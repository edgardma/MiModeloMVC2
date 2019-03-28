using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploPatronAbstractFactoryCar.Products
{
    public class HondaCompactSedan : Interfaces.ISedan
    {
        public string Name()
        {
            return "Honda Amaze";
        }
    }
}
