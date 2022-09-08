#ifndef SENDER_H
#define SENDER_H

#define READINGS_IN_STREAM (50)

#include <iostream>
#include <vector>
#include "../sensor/temperature.h"
#include "../sensor/state_of_charge.h"

bool sendSensorDataToConsole();

#endif // SENDER_H
