using System;
using System.Globalization;
using System.Threading;

class FunWithMatrices
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        double[,] matrix = new double[4, 4];
        matrix[0, 0] = double.Parse(Console.ReadLine());
        double step = double.Parse(Console.ReadLine());
        double previous = matrix[0, 0];
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (i != 0 || j != 0)
                {
                    matrix[i, j] = previous + step;
                    previous = matrix[i, j];
                }
            }
        }
        string[] command = Console.ReadLine().Split();
        while (command[0] != "Game")
        {
            int row = int.Parse(command[0]);
            int col = int.Parse(command[1]);
            double actionNum = double.Parse(command[3]);
            switch (command[2])
            {
                case "multiply": matrix[row,col] *= actionNum;break;
                case "sum": matrix[row, col] += actionNum;break;
                case "power": matrix[row, col] = Math.Pow(matrix[row, col], actionNum);break;
            }
            command = Console.ReadLine().Split();
        }
        double maxRow = double.MinValue;
        int rowIndex = 0;
        double maxCol = double.MinValue;
        int colIndex = 0;
        double left = 0;
        double right = 0;
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            double currentMax = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                currentMax += matrix[i, j];
            }
            if (currentMax > maxRow)
            {
                maxRow = currentMax;
                rowIndex = i;
            }
        }
        for (int j = 0; j < matrix.GetLength(0); j++)
        {
            double currentMax = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                currentMax += matrix[i, j];
            }
            if (currentMax > maxCol)
            {
                maxCol = currentMax;
                colIndex = j;
            }
        }
        for (int i=0; i< matrix.GetLength(0);i++)
        {
            left += matrix[i, i];
        }
        for (int i = 0, j = matrix.GetLength(1) - 1; i < matrix.GetLength(0); j--,i++)
        {
            right += matrix[i, j];
        }
        if (maxRow >= maxCol && maxRow >= left && maxRow >= right)
        {
            Console.WriteLine("ROW[{0}] = {1:F2}", rowIndex, maxRow);
        }
        else if (maxCol> maxRow && maxCol >= left && maxCol >= right)
        {
            Console.WriteLine("COLUMN[{0}] = {1:F2}", colIndex, maxCol);
        }
        else if (left>maxRow&& left>maxCol&& left >= right)
        {
            Console.WriteLine("LEFT-DIAGONAL = {0:F2}", left);
        }
        else if (right>maxRow&& right>maxCol&&right>left)
        {
            Console.WriteLine("RIGHT-DIAGONAL = {0:F2}", right);
        }
    }
}
