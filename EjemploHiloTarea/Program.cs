using System;

using System.Threading;
using System.Threading.Tasks;

namespace EjemploHiloTarea
{
    public class Program
    {
        // http://artesanos.de/software/2011/10/04/tareas-vs-hilos-en-c-3/
        static void Main(string[] args)
        {
            Console.WriteLine("======================================");
            Console.WriteLine("Procesar tareas");
            ProcesarTareas();
            Console.WriteLine("======================================");
            Console.WriteLine("Procesar hilos");
            ProcesarHilos();
            Console.ReadLine();
        }

        static void ProcesarHilos()
        {
            DateTime inicio = DateTime.Now;
            for (int i = 0; i < 100000; i++)
            {
                int temp = i;
                Thread t = new Thread(() => Method1(temp));
                t.Start();
            }

            DateTime fin = DateTime.Now;
            TimeSpan diff = fin - inicio;
            Console.WriteLine("Inicio= {0} - Fin= {1} - Diferencia= {2}:{3}:{4}.{5}",
                               inicio.ToString("yyyy/MM/dd HH:mm:ss.fffffff"),
                               fin.ToString("yyyy/MM/dd HH:mm:ss.fffffff"),
                               diff.Hours, diff.Minutes, diff.Seconds,
                               diff.Milliseconds);
        }

        static void ProcesarTareas()
        {
            DateTime inicio = DateTime.Now;
            for (int i = 0; i < 100000; i++)
            {
                int temp = i;
                Task t = Task.Factory.StartNew(() => Method1(temp));
                //t.Start();
            }
            DateTime fin = DateTime.Now;
            TimeSpan diff = fin - inicio;
            Console.WriteLine("Inicio= {0} - Fin= {1} - Diferencia= {2}:{3}:{4}.{5}",
                                inicio.ToString("yyyy/MM/dd HH:mm:ss.fffffff"),
                                fin.ToString("yyyy/MM/dd HH:mm:ss.fffffff"),
                                diff.Hours, diff.Minutes, diff.Seconds,
                                diff.Milliseconds);
        }

        static void Method1(int i)
        {
            for (int j = 0; j < 10000; j++)
            {
                double d = 45345 / 6546 * 7989 / 0.2254;  //cualquier procesamiento...
            }
        }

        private Program()
        {

        }
    }
}
