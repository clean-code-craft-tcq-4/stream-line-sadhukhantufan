using Receiver;
using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace ReceiverTest
{
    public class RecieverTest
    {
        public List<string> PrepareTestData()
        {
            List<string> sensorParameters = new List<string>();
            sensorParameters.Add("100, 0.5");
            sensorParameters.Add("80, 0.6");
            sensorParameters.Add("10, 0.7");
            sensorParameters.Add("165, 0.1");
            sensorParameters.Add("35.46, 0.3");
            sensorParameters.Add("194.59, 0.4");
            sensorParameters.Add("185.48, 0.7");
            sensorParameters.Add("20, 0.9");
            sensorParameters.Add("37, 1.1");
            sensorParameters.Add("89, 1.25");
            return sensorParameters;
        }

        [Fact (DisplayName ="Test If String Input is converted to Sensor Parameters")]
        public void TestIfInputIsConvertedToSensorParameters()
        {
            var testData = PrepareTestData();
           var inputData =  Utility.ProcessInputData(testData);
            Assert.Equal(testData.Count, inputData.Count);
        }

        [Fact(DisplayName = "Test If Temperature rating matches the input values from console")]
        public void TestIfTemperatureReadingIsSameAsThatOfInputString()
        {
            var testData = PrepareTestData();
            var inputData = Utility.ProcessInputData(testData);
            Assert.Equal(100, inputData[0].Temperature);
            Assert.Equal(80, inputData[1].Temperature);
            Assert.Equal(10, inputData[2].Temperature);
            Assert.Equal(165, inputData[3].Temperature);
            Assert.Equal(35.46f, inputData[4].Temperature);
            Assert.Equal(194.59f, inputData[5].Temperature);
            Assert.Equal(185.48f, inputData[6].Temperature);
            Assert.Equal(20, inputData[7].Temperature);
            Assert.Equal(37, inputData[8].Temperature);
            Assert.Equal(89, inputData[9].Temperature);
        }


        [Fact(DisplayName = "Test If State Of Charge rating matches the input values from console")]
        public void TestIfSOCReadingIsSameAsThatOfInputString()
        {
            var testData = PrepareTestData();
            var inputData = Utility.ProcessInputData(testData);
            Assert.Equal(0.5f, inputData[0].StateOfCharge);
            Assert.Equal(0.6f, inputData[1].StateOfCharge);
            Assert.Equal(0.7f, inputData[2].StateOfCharge);
            Assert.Equal(0.1f, inputData[3].StateOfCharge);
            Assert.Equal(0.3f, inputData[4].StateOfCharge);
            Assert.Equal(0.4f, inputData[5].StateOfCharge);
            Assert.Equal(0.7f, inputData[6].StateOfCharge);
            Assert.Equal(0.9f, inputData[7].StateOfCharge);
            Assert.Equal(1.1f, inputData[8].StateOfCharge);
            Assert.Equal(1.25f, inputData[9].StateOfCharge);
        }

        [Fact]
        public void TestIfMovingAverageIsSameAsThatOfExpectedResult()
        {
            var inputData = Utility.ProcessInputData(PrepareTestData());
            var result = Statistics.CalculateMovingAverage(inputData);
            Assert.Equal(105.214f, result.Item1);
            Assert.Equal(0.87f, result.Item2);
        }

        [Fact]
        public void TestIfMaximumRatingIsSameAsThatOfExpectedResult()
        {
            var inputData = Utility.ProcessInputData(PrepareTestData());
            var result = Statistics.CalculateMaximumRating(inputData);
            Assert.Equal(194.59f, result.Item1);
            Assert.Equal(1.25f, result.Item2);
        }

        [Fact]
        public void TestIfMinimumRatingIsSameAsThatOfExpectedResult()
        {
            var inputData = Utility.ProcessInputData(PrepareTestData());
            var result = Statistics.CalculateMinimumRating(inputData);
            Assert.Equal(10, result.Item1);
            Assert.Equal(0.1f, result.Item2);
        }

        [Fact]
        public void TestIfValuesAreCorrectlyPrintedOnConsole()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            Statistics.PrintValuesOnConsole(new Tuple<float, float>(100.5f, 20f), "Maximum Rating");
            Assert.Equal("Maximum Rating Temperature is100.5\r\nMaximum Rating State Of Charge is100.5\r\n", stringWriter.ToString());
        }

        [Fact]
        public void TestIfAllTheMethodsAreExecutedAndValuesArePrintedOnConsole()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            var inputData = Utility.ProcessInputData(PrepareTestData());
            Statistics.CalculateSensorRatings(inputData);
            Assert.Equal("Moving Average Temperature is105.214\r\nMoving Average State Of Charge is105.214\r\nMinimum Rating Temperature is10\r\nMinimum Rating State Of Charge is10\r\nMaximum Rating Temperature is105.214\r\nMaximum Rating State Of Charge is105.214\r\n"
, stringWriter.ToString());
        }
    }
}
