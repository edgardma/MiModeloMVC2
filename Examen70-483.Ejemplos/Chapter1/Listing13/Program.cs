using System;
using System.Threading;

namespace Examen70_483.Ejemplos.Chapter1.Listing13
{
    public static class Program
    {
        public static void ThreadMethod(Object o)
        {
            for (int i = 0; i < (int)o; i++)
            {
                Console.WriteLine("ThreadProc: {0}", i);
                Thread.Sleep(1000);
            }
        }

        public static void Main()
        {
            Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod));
            t.Start(5);
            t.Join();
        }
    }
}
