using System;

namespace ProvaESSS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Str: abjchba - Output: " + ExibirRespota("abjchba"));
            Console.WriteLine();

            Console.WriteLine("Str: mmop - Output: " + ExibirRespota("mmop"));
            Console.WriteLine();

            Console.WriteLine("Str: kjjjhjjj - Output: " + ExibirRespota("kjjjhjjj"));
            Console.WriteLine();

            Console.Write("Digite uma palavra:");
            string str = Console.ReadLine();

            Console.WriteLine("Str: " + str + " - Output: " + ExibirRespota(str));
        }

        private static string ExibirRespota(string str)
        {
            if (!ValidarTamanhoString(str))
                return "not possible";

            if (VerificarSeStringEhPolindromo(str))
                return str;

            for (int i = 1; i <= 2; i++)
            {
                string letras = RemoverCaracteresDaPalavraETestar(str, i);

                if (letras != string.Empty)
                    return letras;
            }

            return string.Empty;
        }

        private static bool ValidarTamanhoString(string str)
        {
            if (str.Length < 3)
                return false;

            return true;
        }

        private static bool VerificarSeStringEhPolindromo(string str)
        {           
            string strOriginal = str;
            char[] strAux = str.ToCharArray();
            Array.Reverse(strAux);
            string strInvertida = new string(strAux);

            if (strOriginal.Equals(strInvertida))
                return true;

            return false;
        }

        private static string RemoverCaracteresDaPalavraETestar(string str, int n)
        {
            string strNova = string.Empty;
            string letrasExcluidas = string.Empty;

            for (int i = 0; i < str.Length; i++)
            {
                if (i == 0)
                {
                    strNova = str.Substring(n);
                    letrasExcluidas = str.Substring(0, n);
                }
                else
                {
                    if (i + n > str.Length)
                        return string.Empty;

                    strNova = str.Substring(0, i);
                    strNova += str.Substring(i+n);

                    letrasExcluidas = str.Substring(i, n);
                }

                if (!ValidarTamanhoString(strNova))
                    return "not possible";

                if (VerificarSeStringEhPolindromo(strNova))
                {
                    return letrasExcluidas;
                }
            }

            return string.Empty;
        }
    }
}
