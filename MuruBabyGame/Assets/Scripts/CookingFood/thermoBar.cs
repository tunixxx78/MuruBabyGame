using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class thermoBar : MonoBehaviour
{
    public Slider ThermoSlider;

    public void SetMaxTemperature(int thermovalue)
    {
        ThermoSlider.maxValue = thermovalue;
        ThermoSlider.value = thermovalue;
    }

    public void SetTemperature(int thermovalue)
    {
        ThermoSlider.value = thermovalue;
    }
}
