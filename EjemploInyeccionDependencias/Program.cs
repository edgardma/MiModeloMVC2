using System;
using EjemploInyeccionDependencias.Vehiculos;

namespace EjemploInyeccionDependencias
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehiculo vehiculoDiesel = VehiculoFactory.Create(TipoMotor.MOTOR_DIESEL);
            vehiculoDiesel.Motor.Acelerar();

            Vehiculo vehiculoGasolina = VehiculoFactory.Create(TipoMotor.MOTOR_GASOLINA);
            vehiculoGasolina.Motor.Acelerar();

            Console.ReadLine();
        }
    }
}
