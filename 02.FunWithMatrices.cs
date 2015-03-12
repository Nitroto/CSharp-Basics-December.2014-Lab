using System;
using System.Globalization;
using System.Threading;

class FunWithMatrices
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        double startNum = double.Parse(Console.ReadLine());
        double step = double.Parse(Console.ReadLine());
        double[,] matrice = new double[4, 4];
        double previousValue = 0;
        for (int i = 0; i < matrice.GetLength(0); i++)
        {
            for (int j = 0; j < matrice.GetLength(1); j++)
            {
                if (i == 0 && j == 0)
                {
                    matrice[i, j] = startNum;
                }
                else
                {
                    matrice[i, j] = previousValue + step;
                }
                previousValue = matrice[i, j];
            }
        }
        string userInput = Console.ReadLine();
        bool gameOver = userInput == "Game Over!";
        while (!gameOver)
        {
            string[] command = userInput.Split(' ');
            int row = int.Parse(command[0]);
            int col = int.Parse(command[1]);
            string action = command[2];
            double actionNum = double.Parse(command[3]);
            matrice[row, col] = DoAction(matrice[row, col], actionNum, action);
            userInput = Console.ReadLine();
            gameOver = userInput == "Game Over!";
        }
        int biggestRow = GetBiggestRow(matrice);
        double sumOfBiggestRow = GetBiggestRowSum(matrice);
        int bigestCol = GetBiggestCol(matrice);
        double sumOfBiggestCol = GetBiggestColSum(matrice);
        double leftDiagonal = GetSumOfLeftDiagonal(matrice);
        double rightDiagonal = GetSumOfRightDiagonal(matrice);
        if (sumOfBiggestRow >= sumOfBiggestCol && sumOfBiggestRow >= leftDiagonal && sumOfBiggestRow >= rightDiagonal)
        {
            Console.WriteLine("ROW[{0}] = {1:F2}", biggestRow, sumOfBiggestRow);
        }
        else if (sumOfBiggestCol > sumOfBiggestRow && sumOfBiggestCol >= leftDiagonal && sumOfBiggestCol >= rightDiagonal)
        {
            Console.WriteLine("COLUMN[{0}] = {1:F2}", bigestCol, sumOfBiggestCol);
        }
        else if (leftDiagonal > sumOfBiggestRow && leftDiagonal > sumOfBiggestCol && leftDiagonal >= rightDiagonal)
        {
            Console.WriteLine("LEFT-DIAGONAL = {0:F2}", leftDiagonal);
        }
        else if (rightDiagonal > sumOfBiggestRow && rightDiagonal > sumOfBiggestCol && rightDiagonal > leftDiagonal)
        {
            Console.WriteLine("RIGHT-DIAGONAL = {0:F2}", rightDiagonal);
        }
    }
    static double DoAction(double num, double actionValue, string action)
    {
        double returnValue = 0;
        switch (action)
        {
            case "multiply": returnValue = num * actionValue; break;
            case "sum": returnValue = num + actionValue; break;
            case "power": returnValue = Math.Pow(num, actionValue); break;
        }
        return returnValue;
    }
    static int GetBiggestRow(double[,] array)
    {
        double biggestRowSum = double.MinValue;
        int row = 0;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            double rowSum = 0;
            for (int j = 0; j < array.GetLength(1); j++)
            {
                rowSum += array[i, j];
            }
            if (rowSum > biggestRowSum)
            {
                biggestRowSum = rowSum;
                row = i;
            }
        }
        return row;
    }
    static double GetBiggestRowSum(double[,] array)
    {
        double biggestRowSum = double.MinValue;
        int row = 0;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            double rowSum = 0;
            for (int j = 0; j < array.GetLength(1); j++)
            {
                rowSum += array[i, j];
            }
            if (rowSum > biggestRowSum)
            {
                biggestRowSum = rowSum;
                row = i;
            }
        }
        return biggestRowSum;
    }
    static int GetBiggestCol(double[,] array)
    {
        double biggestColSum = double.MinValue;
        int col = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            double colSum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                colSum += array[i, j];
            }
            if (colSum > biggestColSum)
            {
                biggestColSum = colSum;
                col = j;
            }
        }
        return col;
    }
    static double GetBiggestColSum(double[,] array)
    {
        double biggestColSum = double.MinValue;
        int col = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            double colSum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                colSum += array[i, j];
            }
            if (colSum > biggestColSum)
            {
                biggestColSum = colSum;
                col = j;
            }
        }
        return biggestColSum;
    }
    static double GetSumOfLeftDiagonal(double[,] array)
    {
        double sum = 0;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            sum += array[i, i];
        }
        return sum;
    }
    static double GetSumOfRightDiagonal(double[,] array)
    {

        double sum = 0;
        int j = array.GetLength(1);
        for (int i = 0; i < array.GetLength(0); i++)
        {
            j--;
            sum += array[i, j];
        }
        return sum;
    }
}