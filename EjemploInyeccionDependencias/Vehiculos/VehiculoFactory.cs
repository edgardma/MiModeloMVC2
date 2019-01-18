namespace EjemploInyeccionDependencias.Vehiculos
{
    public class VehiculoFactory
    {
        public static Vehiculo Create(TipoMotor tipo)
        {
            Vehiculo v = null;

            switch (tipo)
            {
                case TipoMotor.MOTOR_DIESEL:
                    v = new Vehiculo(new MotorDiesel());
                    break;
                case TipoMotor.MOTOR_GASOLINA:
                    v = new Vehiculo(new MotorGasolina());
                    break;
                default:
                    break;
            }

            return v;
        }
    }
}
