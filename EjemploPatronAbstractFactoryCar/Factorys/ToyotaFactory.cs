using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EjemploPatronAbstractFactoryCar.Interfaces;
using EjemploPatronAbstractFactoryCar.Products;

namespace EjemploPatronAbstractFactoryCar.Factorys
{
    public class ToyotaFactory : Interfaces.ICarFactory
    {
        public ISedan ManufactureSedan(string segment)
        {
            switch (segment)
            {
                case "compact":
                    return new ToyotaCompactSedan();
                case "full":
                    return new ToyotaFullSedan();
                default:
                    throw new Exception();
            }
        }

        public ISuv ManufactureSuv(string segment)
        {
            switch (segment)
            {
                case "compact":
                    return new ToyotaCompactSuv();
                case "full":
                    return new ToyotaFullSuv();
                default:
                    throw new Exception();
            }
        }
    }
}
