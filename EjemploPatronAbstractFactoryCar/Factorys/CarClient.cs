using EjemploPatronAbstractFactoryCar.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploPatronAbstractFactoryCar.Factorys
{
    public class CarClientAbstractFactory
    {
        private ISedan sedan;
        private ISuv suv;

        public CarClientAbstractFactory(ICarFactory factory, string segment)
        {
            sedan = factory.ManufactureSedan(segment);
            suv = factory.ManufactureSuv(segment);
        }

        public string GetManufacturedSedanName()
        {
            return sedan.Name();
        }

        public string GetManufacturedSuvName()
        {
            return suv.Name();
        }
    }
}
