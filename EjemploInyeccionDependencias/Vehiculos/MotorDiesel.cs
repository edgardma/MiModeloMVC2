using System;

namespace EjemploInyeccionDependencias.Vehiculos
{
    public class MotorDiesel : IMotor
    {
        public void Acelerar()
        {
            Console.WriteLine("Acelarar Motor Diesel");
        }

        public int GetRevoluciones()
        {
            return 150;
        }
    }
}
