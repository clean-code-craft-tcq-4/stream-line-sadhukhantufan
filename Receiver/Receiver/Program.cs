using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Receiver
{
    public static class Program
    {
        [ExcludeFromCodeCoverage]
        public static void Main(string[] args)
        {
            List<string> sensorInputFromConsole = new List<string>();

            // considering the sender and reciever are integrated and values are read from the console
            for (int i = 0; i < 50; i++)
            {
                sensorInputFromConsole.Add(Console.ReadLine());
            }

            Statistics.CalculateSensorRatings(Utility.ProcessInputData(sensorInputFromConsole));
        }
    }
}
