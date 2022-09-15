#ifndef STATE_OF_CHARGE_H
#define STATE_OF_CHARGE_H

#include <vector>
#include <iostream>

#define SOC_MIN_VALUE (0)
#define SOC_MAX_VALUE (100)

std::vector<int> generateSocValues(int socMaxValue, int socMinValue, int numberOfReadings);

#endif // STATE_OF_CHARGE_H
