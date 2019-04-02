using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploPatronAdapterMotores
{
    public sealed class Motores
    {
        private Motores() { }

        public static void UsarMotorComun()
        {
            Motor motor = new MotorComun();
            motor.Encender();
            motor.Acelerar();
            motor.Apagar();
        }

        public static void UsarMotorElectrico()
        {
            Motor motor = new MotorElectricoAdapter();
            motor.Encender();
            motor.Acelerar();
            motor.Apagar();
        }

        public static void UsarMotorEconomico()
        {
            Motor motor = new MotorEconomico();
            motor.Encender();
            motor.Acelerar();
            motor.Apagar();
        }
    }
}
