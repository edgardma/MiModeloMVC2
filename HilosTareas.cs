using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplicationHilos
{
    class Program
    {
        // http://artesanos.de/software/2011/10/04/tareas-vs-hilos-en-c-3/
        static void Main(string[] args)
        {
            ProcesarTareas();
        }

        static void ProcesarHilos()
        {
            DateTime inicio = DateTime.Now;
            for (int i = 0; i < 100000; i++)
            {
                int temp = i;
                Thread t = new Thread(() => method1(temp));
                t.Start();
            }

            DateTime fin = DateTime.Now;
            TimeSpan diff = fin - inicio;
            Console.WriteLine("Inicio= {0} - Fin= {1} - Diferencia= {2}:{3}:{4}.{5}",
                               inicio.ToString("yyyy/MM/dd HH:mm:ss.fffffff"),
                               fin.ToString("yyyy/MM/dd HH:mm:ss.fffffff"),
                               diff.Hours, diff.Minutes, diff.Seconds,
                               diff.Milliseconds);
            Console.ReadLine();
        }

        static void ProcesarTareas() 
        {
            DateTime inicio = DateTime.Now;
            for (int i = 0; i < 100000; i++)
            {
                int temp = i;
                Task t = Task.Factory.StartNew(() => method1(temp));
            }
            DateTime fin = DateTime.Now;
            TimeSpan diff = fin - inicio;
            Console.WriteLine("Inicio= {0} - Fin= {1} - Diferencia= {2}:{3}:{4}.{5}",
                                inicio.ToString("yyyy/MM/dd HH:mm:ss.fffffff"),
                                fin.ToString("yyyy/MM/dd HH:mm:ss.fffffff"),
                                diff.Hours, diff.Minutes, diff.Seconds,
                                diff.Milliseconds);
            Console.ReadLine();
        }

        static void method1(int i)
        {
            for (int j = 0; j < 10000; j++)
            {
                double d = 45345 / 6546 * 7989 / 0.2254;  //cualquier procesamiento...
            }
        }
    }
}
