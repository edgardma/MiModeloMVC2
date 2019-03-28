using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploPatronAbstractFactoryCar.Products
{
    public class ToyotaCompactSuv : Interfaces.ISuv
    {
        public string Name()
        {
            return "Toyota Rav-4";
        }
    }
}
