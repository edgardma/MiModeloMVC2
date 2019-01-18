using System;

namespace EjemploInyeccionDependencias.Vehiculos
{
    public class MotorGasolina : IMotor
    {
        public void Acelerar()
        {
            Console.WriteLine("Acelarar Motor Gasolina");
        }

        public int GetRevoluciones()
        {
            return 100;
        }
    }
}
