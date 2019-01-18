using System;

namespace EjemploInyeccionDependencias.Vehiculos
{
    public class Vehiculo
    {
        private IMotor motor;

        public Vehiculo(IMotor motorVehiculo)
        {
            motor = motorVehiculo;
        }

        public IMotor Motor { get => motor; set => motor = value; }

        public int GetRevolucionesMotor()
        {
            if (motor != null)
                return motor.GetRevoluciones();
            else
                return -1;
        }
    }
}
