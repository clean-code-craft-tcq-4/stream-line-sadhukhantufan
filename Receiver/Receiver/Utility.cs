using System;
using System.Collections.Generic;

namespace Receiver
{
    public static class Utility
    {
        public static List<SensorParameter> ProcessInputData(List<string> sensorInputFromConsole)
        {
            List<SensorParameter> sensorParameters = new List<SensorParameter>();
            foreach (string Senderinput in sensorInputFromConsole)
            {
                string[] splitdata = Senderinput.Split(", ");
                sensorParameters.Add(new SensorParameter()
                {
                    Temperature = (float)Convert.ToDouble(splitdata[0]),
                    StateOfCharge = (float)Convert.ToDouble(splitdata[1])
                });
            }
            return sensorParameters;
        }
    }
}
