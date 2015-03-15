using System;
using System.Globalization;
using System.Linq;
using System.Threading;

class Program
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int[] size = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();
        char[,] matrix = new char[size[0],size[1]];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            char[] line = Console.ReadLine().ToCharArray();
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = line[j];
            }
        }
        int figI = 0, figL = 0, figJ = 0, figO = 0, figZ = 0, figS = 0, figT = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                figI += FindFigure(matrix, i, j, i + 1, j, i + 2, j, i + 3, j);
                figL += FindFigure(matrix, i, j, i + 1, j, i + 2, j, i + 2, j + 1);
                figJ += FindFigure(matrix, i, j, i + 1, j, i + 2, j, i + 2, j - 1);
                figO += FindFigure(matrix, i, j, i, j + 1, i + 1, j, i + 1, j + 1);
                figS += FindFigure(matrix, i, j, i, j + 1, i + 1, j, i + 1, j - 1);
                figT += FindFigure(matrix, i, j, i, j + 1, i, j + 2, i + 1, j + 1);
                figZ += FindFigure(matrix, i, j, i, j + 1, i + 1, j + 1, i + 1, j + 2);
            }
        }
        Console.WriteLine("I:{0}, L:{1}, J:{2}, O:{3}, Z:{4}, S:{5}, T:{6}", figI, figL, figJ, figO, figZ, figS, figT);
    }
    public static int FindFigure(char[,] matrix, int r1, int c1, int r2, int c2, int r3, int c3, int r4, int c4)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        bool inPlayField = IsInPlayField(r1, rows) && IsInPlayField(c1, cols) &&
                           IsInPlayField(r2, rows) && IsInPlayField(c2, cols) &&
                           IsInPlayField(r3, rows) && IsInPlayField(c3, cols) &&
                           IsInPlayField(r4, rows) && IsInPlayField(c4, cols);
        bool isFigure = false;
        if (inPlayField)
        {
            isFigure = matrix[r1, c1] == 'o' && matrix[r2, c2] == 'o' && matrix[r3, c3] == 'o' && matrix[r4, c4] == 'o';
        }
        return isFigure ? 1 : 0;
    }
    public static bool IsInPlayField(int point, int boarder)
    {
        return (0 <= point) && (point < boarder);
    }
}
