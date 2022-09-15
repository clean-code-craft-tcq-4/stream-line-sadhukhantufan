using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Receiver
{
    public static class Statistics
    {
        public static void CalculateSensorRatings(List<SensorParameter> sensorParameters)
        {
            var movingAverage = CalculateMovingAverage(sensorParameters);
            PrintValuesOnConsole(movingAverage, "Moving Average");
            var minimumRating = CalculateMinimumRating(sensorParameters);
            PrintValuesOnConsole(minimumRating, "Minimum Rating");
            var maximumRating = CalculateMovingAverage(sensorParameters);
            PrintValuesOnConsole(maximumRating, "Maximum Rating");
        }

        public static Tuple<float, float> CalculateMovingAverage(List<SensorParameter> sensorParameters)
        {
            var latestValues = sensorParameters.TakeLast(5);

            return new Tuple<float, float>(latestValues.Select((e) => e.Temperature).Average(), latestValues.Select((e) => e.StateOfCharge).Average());
        }

        public static Tuple<float, float> CalculateMinimumRating(List<SensorParameter> sensorParameters)
        {
            return new Tuple<float, float>(sensorParameters.Select((e) => e.Temperature).Min(), sensorParameters.Select((e) => e.StateOfCharge).Min());
        }

        public static Tuple<float, float> CalculateMaximumRating(List<SensorParameter> sensorParameters)
        {
            return new Tuple<float, float>(sensorParameters.Select((e) => e.Temperature).Max(), sensorParameters.Select((e) => e.StateOfCharge).Max());

        }

        public static void PrintValuesOnConsole(Tuple<float, float> ratings, string calculationType)
        {
            Console.WriteLine(calculationType + " Temperature is" + ratings.Item1);
            Console.WriteLine(calculationType + " State Of Charge is" + ratings.Item1);
        }
    }
}
