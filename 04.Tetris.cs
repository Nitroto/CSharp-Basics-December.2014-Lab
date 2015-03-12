using System;
using System.Globalization;
using System.Threading;

class Tetris
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        string[] matrixSize = Console.ReadLine().Split(' ');
        int row = int.Parse(matrixSize[0]);
        int col = int.Parse(matrixSize[1]);
        char[,] matrix = new char[row, col];
        for (int i = 0; i < row; i++)
        {
            char[] line = Console.ReadLine().ToCharArray();
            for (int j = 0; j < col; j++)
            {
                matrix[i, j] = line[j];
            }
        }
        int figI=0, figL=0, figJ=0, figO=0, figZ=0, figS=0, figT = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                figI += FindFigure(matrix, i, j, i + 1, j, i + 2, j, i + 3, j);
                figJ += FindFigure(matrix, i, j, i + 1, j, i + 2, j, i + 2, j - 1);
                figL += FindFigure(matrix, i, j, i + 1, j, i + 2, j, i + 2, j + 1);
                figO += FindFigure(matrix, i, j, i, j + 1, i + 1, j, i + 1, j + 1);
                figS += FindFigure(matrix, i, j, i, j + 1, i + 1, j, i + 1, j - 1);
                figT += FindFigure(matrix, i, j, i, j + 1, i, j + 2, i + 1, j + 1);
                figZ += FindFigure(matrix, i, j, i, j + 1, i + 1, j + 1, i + 1, j + 2);
            }
        }
        Console.WriteLine("I:{0}, L:{1}, J:{2}, O:{3}, Z:{4}, S:{5}, T:{6}", figI,figL, figJ,figO,figZ,figS,figT);
    }
    static int FindFigure(char[,] matrix, int r0, int c0, int r1, int c1, int r2, int c2, int r3, int c3)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        bool inPlayField = IsInPlayField(r0, rows) && IsInPlayField(c0, cols) &&
                           IsInPlayField(r1, rows) && IsInPlayField(c1, cols) &&
                           IsInPlayField(r2, rows) && IsInPlayField(c2, cols) &&
                           IsInPlayField(r3, rows) && IsInPlayField(c3, cols);
        bool isFigure = false;
        if (inPlayField)
        {
            isFigure = matrix[r0, c0] == 'o' && matrix[r1, c1] == 'o' && matrix[r2, c2] == 'o' && matrix[r3, c3] == 'o';
        }
        return isFigure ? 1 : 0;
    }
    static bool IsInPlayField(int point, int boarder)
    {
        bool inBoarder = 0 <= point && point < boarder;
        return inBoarder;
    }
}
