using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrInt1 = new int[] { 4, 6, 23, 10, 1, 3 };
            int[] arrInt2 = new int[] { 5, 7, 16, 1, 2 };
            int[] arrInt3 = new int[] { 3, 5, -1, 8, 12 };

            Console.Write("new int[] { 4, 6, 23, 10, 1, 3 }: ");
            Console.WriteLine(VerificaSomaElementos(arrInt1));

            Console.Write("new int[] { 5, 7, 16, 1, 2 }: ");
            Console.WriteLine(VerificaSomaElementos(arrInt2));

            Console.Write("new int[] { 3, 5, -1, 8, 12 }: ");
            Console.WriteLine(VerificaSomaElementos(arrInt3));
                       
        }

        private static bool VerificaSomaElementos(int[] elementos)
        {
            Array.Sort(elementos);
            Array.Reverse(elementos);
            
            int maxValue = elementos[0];
            int total = 0;

            for (int i = 0; i < elementos.Length; i++)
            {
                if (elementos[i] != maxValue)
                {
                    total += elementos[i];
                }
            }

            return total >= maxValue;
        }
    }
}
