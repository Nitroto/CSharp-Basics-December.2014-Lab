using System;
using System.Globalization;
using System.Threading;

class CountBeers
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        string[] command = Console.ReadLine().Split(' ');
        int sumOfStacks = 0;
        int sumOfBeers = 0;
        while (command[0] != "End")
        {
            int quantity = int.Parse(command[0]);
            if (command[1] == "stacks")
            {
                sumOfStacks += quantity;
            }
            else
            {
                sumOfBeers += quantity;
            }
            command = Console.ReadLine().Split(' ');
        }
        sumOfStacks += sumOfBeers / 20;
        sumOfBeers = sumOfBeers % 20;
        Console.WriteLine("{0} stacks + {1} beers", sumOfStacks, sumOfBeers);
    }
}
