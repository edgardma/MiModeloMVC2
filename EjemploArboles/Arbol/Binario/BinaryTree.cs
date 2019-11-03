using System;
using System.Collections.Generic;

namespace EjemploArboles.Arbol.Binario
{
    public class BinaryTree
    {
        private BinaryNode root;
        private int count;
        private readonly IComparer<int> comparer = Comparer<int>.Default;

        public BinaryTree()
        {
            root = null;
            count = 0;
        }

        public bool Add(int item)
        {
            if (root == null)
            {
                root = new BinaryNode(item);
                count++;
                return true;
            }
            else
            {
                return AddSub(root, item);
            }
        }

        private bool AddSub(BinaryNode node, int item)
        {
            if (comparer.Compare(node.Item, item) < 0)
            {
                if (node.Right == null)
                {
                    node.Right = new BinaryNode(item);
                    count++;
                    return true;
                }
                else
                {
                    return AddSub(node.Right, item);
                }
            }
            else if (comparer.Compare(node.Item, item) > 0)
            {
                if (node.Left == null)
                {
                    node.Left = new BinaryNode(item);
                    count++;
                    return true;
                }
                else
                {
                    return AddSub(node.Left, item);
                }
            }
            else
            {
                return false;
            }
        }

        public void Print()
        {
            Print(root, 4);
        }

        public void Print(BinaryNode p, int padding)
        {
            if (p != null)
            {
                if (p.Right != null)
                {
                    Print(p.Right, padding + 4);
                }
                if (padding > 0)
                {
                    Console.Write(" ".PadLeft(padding));
                }
                if (p.Right != null)
                {
                    Console.Write("/\n");
                    Console.Write(" ".PadLeft(padding));
                }
                Console.Write(p.Item.ToString() + "\n ");
                if (p.Left != null)
                {
                    Console.Write(" ".PadLeft(padding) + "\\\n");
                    Print(p.Left, padding + 4);
                }
            }
        }

        public BinaryNode PrintBinaryTree { get { return root; } }

        public void Print2()
        {
            PrintBinaryTree.Print();
        }

        public void PreOrden()
        {
            PreOrden(root);
        }

        private void PreOrden(BinaryNode nodo)
        {
            if (nodo == null)
            {
                return;
            }

            Console.WriteLine("Nodo valor => " + nodo.Item);
            PreOrden(nodo.Left);
            PreOrden(nodo.Right);
        }

        public void PostOrden()
        {
            PostOrden(root);
        }

        private void PostOrden(BinaryNode nodo)
        {
            if (nodo == null)
            {
                return;
            }

            PostOrden(nodo.Left);
            PostOrden(nodo.Right);
            Console.WriteLine("Nodo valor => " + nodo.Item);
        }

        public void InOrden()
        {
            InOrden(root);
        }

        private void InOrden(BinaryNode nodo)
        {
            if (nodo == null)
            {
                return;
            }

            InOrden(nodo.Left);
            Console.WriteLine("Nodo valor => " + nodo.Item);
            InOrden(nodo.Right);
        }
    }
}
