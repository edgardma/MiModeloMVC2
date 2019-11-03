namespace EjemploArboles.Arbol.Binario
{
    public class BinaryNode
    {
        public BinaryNode(int item)
        {
            Item = item;
        }

        public int Item { get; set; }

        public BinaryNode Right { get; set; }

        public BinaryNode Left { get; set; }
    }
}
