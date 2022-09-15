#define CATCH_CONFIG_MAIN

#include <iostream>
#include <vector>

#include "test/catch.hpp"

#include "sensor/temperature.h"
#include "sensor/state_of_charge.h"
#include "sender/sender.h"

using namespace std;

TEST_CASE("Check whether 50 random temperature values are generated or not")
{
    std::vector<int> generatedTemperatureValues = generateTemperatureValues(TEMPERATURE_MAX_VALUE, TEMPERATURE_MIN_VALUE, READINGS_IN_STREAM);
    bool isTemperatureBufferEmpty = generatedTemperatureValues.empty();
    REQUIRE(isTemperatureBufferEmpty == false);
    int temperatureBufferSize = generatedTemperatureValues.size();
    REQUIRE(temperatureBufferSize == READINGS_IN_STREAM);
}

TEST_CASE("Check whether 50 random SOC values are generated or not")
{
    std::vector<int> generatedSocValues = generateSocValues(SOC_MAX_VALUE, SOC_MIN_VALUE, READINGS_IN_STREAM);
    bool isSocBufferEmpty = generatedSocValues.empty();
    REQUIRE(isSocBufferEmpty == false);
    int socBufferSize = generatedSocValues.size();
    REQUIRE(socBufferSize == READINGS_IN_STREAM);
}

TEST_CASE("Check whether 50 random temperature, SOC values are sent to console successfully")
{
    bool isSendSensorDataToConsole = sendSensorDataToConsole();
    REQUIRE(isSendSensorDataToConsole == true);
}
