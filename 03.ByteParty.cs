using System;
using System.Globalization;
using System.Threading;

class Program
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int n = int.Parse(Console.ReadLine());
        byte[] values = new byte[n];
        for (int i = 0; i < values.Length; i++)
        {
            values[i] = byte.Parse(Console.ReadLine());
        }
        string[] command = Console.ReadLine().Split();
        while (command[0] != "party")
        {
            byte position = byte.Parse(command[1]);
            string action = command[0];
            for (int i=0; i <values.Length;i++)
            switch (action)
                {
                    case "-1": values[i] ^= (byte)(1 << position); break;
                    case "0": values[i] &= (byte)~(1 << position); break;
                    case "1": values[i] |= (byte)(1 << position); break;
                }
            command = Console.ReadLine().Split();
        }
        foreach (byte value in values)
        {
            Console.WriteLine("{0}", value);
        }
    }
}
