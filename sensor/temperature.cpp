#include "temperature.h"

using namespace std;

std::vector<int> generateTemperatureValues(int teperatureMaxValue, int teperatureMinValue, int numberOfReadings)
{
  std::vector<int> temperatureValueList;
  for (int counter = 0; counter < numberOfReadings; counter++)
  {
    int randomValue = rand() % teperatureMaxValue + teperatureMinValue;
    temperatureValueList.push_back(randomValue);
  }
  return temperatureValueList;
}
