#ifndef TEMPERATURE_H
#define TEMPERATURE_H

#include <iostream>
#include <vector>

#define TEMPERATURE_MIN_VALUE (-50)
#define TEMPERATURE_MAX_VALUE (150)

std::vector<int> generateTemperatureValues(int teperatureMaxValue, int teperatureMinValue, int numberOfReadings);

#endif // TEMPERATURE_H
