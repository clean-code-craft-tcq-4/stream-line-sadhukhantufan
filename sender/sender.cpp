#include "sender.h"

using namespace std;

bool sendSensorDataToConsole()
{
  bool isDataSendSuccessfully = false;
  std::vector<int> temperatureValues = generateTemperatureValues(TEMPERATURE_MAX_VALUE, TEMPERATURE_MIN_VALUE, READINGS_IN_STREAM);
  std::vector<int> socValues = generateSocValues(SOC_MAX_VALUE, SOC_MIN_VALUE, READINGS_IN_STREAM);

  if ((temperatureValues.size() == READINGS_IN_STREAM) && (socValues.size() == READINGS_IN_STREAM))
  {
    for (int counter = 0; counter < READINGS_IN_STREAM; counter++)
    {
      std::cout << temperatureValues[counter] << ", " << socValues[counter] << std::endl;
    }
    isDataSendSuccessfully = true;
  }
  return isDataSendSuccessfully;
}
