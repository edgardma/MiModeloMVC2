using EjemploArboles.Arbol.Binario;
using System;

namespace EjemploArboles
{
    public class Program
    {
        // https://codeday.me/es/qa/20190320/336719.html
        static void Main(string[] args)
        {
            BinaryTree btr = new BinaryTree();
            btr.Add(6);
            btr.Add(2);
            btr.Add(3);
            btr.Add(11);
            btr.Add(30);
            btr.Add(9);
            btr.Add(13);
            btr.Add(18);

            btr.Print2();
            Console.WriteLine("Pre-Orden");
            btr.PreOrden();
            Console.WriteLine("Post-Orden");
            btr.PostOrden();
            Console.WriteLine("In-Orden");
            btr.InOrden();

            Console.ReadLine();
        }

        private Program()
        {
            
        }
    }
}
