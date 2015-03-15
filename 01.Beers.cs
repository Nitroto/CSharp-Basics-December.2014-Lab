using System;
using System.Globalization;
using System.Threading;

class Beers
{
    static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        string[] command = Console.ReadLine().Split();
        int totalCountOfBeers = 0;
        while (command[0] != "End")
        {
            int count = int.Parse(command[0]);
            string container = command[1];
            switch (container)
            {
                case "stacks": totalCountOfBeers += count * 20;break;
                case "beers": totalCountOfBeers += count;break;
            }
            command = Console.ReadLine().Split();
        }
        Console.WriteLine("{0} stacks + {1} beers", totalCountOfBeers/20, totalCountOfBeers%20);
    }
}
