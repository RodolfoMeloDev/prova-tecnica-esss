using System;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strArr = new string[] { "[1, 2, 3, 4, 5]", "[6, 7, 8, 9, 10]", "[11, 12, 13, 14, 15]", "[16, 17, 18, 19, 20]", "[21, 22, 23, 24, 25]" };

            int rows = strArr.Length;
            int cols = strArr[0].Split(",").Length;

            Console.WriteLine("row: " + rows);
            Console.WriteLine("col: " + cols);

            string[,] mat = new string[rows, cols];

            mat = MontarMatriz(strArr, rows, cols);

            bool readFirstRow = true;
            bool readLastCol = true;

            string result = RetornarValoresMatriz(mat, rows, cols, ref readFirstRow, ref readLastCol);

            Console.WriteLine(result.Substring(0, result.Length -1));
        }

        private static string[,] MontarMatriz(string[] arr, int rows, int cols)
        {
            string[,] mat = new string[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                string[] values = arr[i].Replace("[", "").Replace("]", "").Replace(" ", "").Split(",");

                for (int j = 0; j < cols; j++)
                {
                    mat[i, j] = values[j];
                }
            }

            return mat;
        }

        private static bool ExisteValoesMatriz(string[,] mat, int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (mat[i, j] != null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static bool ExisteValorPosicao(string[,] mat, int row, int col)
        {
            if (mat[row, col] != null)
            {
                return true;
            }

            return false;
        }

        private static bool ExisteValorLinha(string[,] mat, int row, int cols)
        {
            for (int i = 0; i < cols; i++)
            {
                if (ExisteValorPosicao(mat, row, i))
                {
                    return true;
                }
            }
            return false;
        }

        private static bool ExisteValorColuna(string[,] mat, int rows, int col)
        {
            for (int i = 0; i < rows; i++)
            {
                if (ExisteValorPosicao(mat, i, col))
                {
                    return true;
                }
            }
            return false;
        }

        private static string RetornarValoresMatriz(string[,] mat, int rows, int cols, ref bool readFirstRow, ref bool readLastCol)
        {
            StringBuilder sb = new StringBuilder();

            if (!ExisteValoesMatriz(mat, rows, cols))
            {
                return sb.ToString();
            }

            if (readFirstRow && readLastCol)
            {
                for (int i = 0; i < rows; i++)
                {
                    if (ExisteValorLinha(mat, i, cols))
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            if (ExisteValorPosicao(mat, i, j))
                            {
                                sb.Append(mat[i, j] + ",");
                                mat[i, j] = null;
                            }
                        }
                        readFirstRow = false;
                        sb.Append(RetornarValoresMatriz(mat, rows, cols, ref readFirstRow, ref readLastCol));
                    }
                }
            }
            else if (!readFirstRow && readLastCol)
            {
                int lastCol = cols - 1;

                for (int i = 0; i < rows; i++)
                {
                    if (ExisteValorColuna(mat, rows, lastCol))
                    {
                        if (ExisteValorPosicao(mat, i, lastCol))
                        {
                            sb.Append(mat[i, lastCol] + ",");
                            mat[i, lastCol] = null;
                        }
                    }
                    else
                    {
                        i = 0;
                        lastCol--;

                        if (lastCol < 0 || sb.ToString() != String.Empty)
                        {
                            break;
                        }
                    }
                }

                readLastCol = false;
                sb.Append(RetornarValoresMatriz(mat, rows, cols, ref readFirstRow, ref readLastCol));
            }
            else if (!readFirstRow && !readLastCol)
            {
                int lastRow = rows - 1;
                int lastCol = cols - 1;

                for (int i = lastRow; i >= 0; i--)
                {
                    if (ExisteValorLinha(mat, i, cols))
                    {
                        for (int j = lastCol; j >= 0; j--)
                        {
                            if (ExisteValorPosicao(mat, i, j))
                            {
                                sb.Append(mat[i, j] + ",");
                                mat[i, j] = null;
                            }
                        }
                        readFirstRow = true;
                        sb.Append(RetornarValoresMatriz(mat, rows, cols, ref readFirstRow, ref readLastCol));
                    }
                    else
                    {
                        lastRow--;

                        if (lastCol < 0)
                        {
                            break;
                        }
                    }
                }

                readFirstRow = true;
            }
            else if (readFirstRow && !readLastCol)
            {
                int col = 0;

                for (int i = rows - 1; i >= 0; i--)
                {
                    if (ExisteValorColuna(mat, rows, col))
                    {
                        if (ExisteValorPosicao(mat, i, col))
                        {
                            sb.Append(mat[i, col] + ",");
                            mat[i, col] = null;
                        }
                    }
                    else
                    {
                        i = 0;
                        col++;

                        if (col > cols)
                        {
                            break;
                        }
                    }
                }

                readLastCol = true;
                sb.Append(RetornarValoresMatriz(mat, rows, cols, ref readFirstRow, ref readLastCol));
            }

            return sb.ToString();
        }
    }
}