using System;
using System.Globalization;
using System.Threading;

class ByteParty
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int n = int.Parse(Console.ReadLine());
        byte[] values = new byte[n];
        for (int i = 0; i < n; i++)
        {
            values[i] = byte.Parse(Console.ReadLine());
        }
        string userInput = Console.ReadLine();
        while (userInput != "party over")
        {
            string[] commands = userInput.Split(' ');
            string command = commands[0];
            byte position = byte.Parse(commands[1]);
            for (int i = 0; i < values.Length; i++)
            {
                switch (command)
                {
                    case "-1": values[i] ^= (byte)(1 << position); break;
                    case "0": values[i] &= (byte)~(1 << position); break;
                    case "1": values[i] |= (byte)(1 << position); break;
                }
            }
            userInput = Console.ReadLine();
        }
        foreach (byte value in values)
        {
            Console.WriteLine(value);
        }
    }
}
