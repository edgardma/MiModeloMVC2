using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploPatronAbstractFactoryCar.Products
{
    public class ToyotaFullSuv : Interfaces.ISuv
    {
        public string Name()
        {
            return "Toyota Highlander";
        }
    }
}
