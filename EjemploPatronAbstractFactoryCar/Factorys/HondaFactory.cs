using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EjemploPatronAbstractFactoryCar.Interfaces;
using EjemploPatronAbstractFactoryCar.Products;

namespace EjemploPatronAbstractFactoryCar.Factorys
{
    public class HondaFactory : Interfaces.ICarFactory
    {
        public ISedan ManufactureSedan(string segment)
        {
            switch (segment)
            {
                case "compact":
                    return new HondaCompactSedan();
                case "full":
                    return new HondaFullSedan();
                default:
                    throw new Exception();
            }
        }

        public ISuv ManufactureSuv(string segment)
        {
            switch (segment)
            {
                case "compact":
                    return new HondaCompactSuv();
                case "full":
                    return new HondaFullSuv();
                default:
                    throw new Exception();
            }
        }
    }
}
