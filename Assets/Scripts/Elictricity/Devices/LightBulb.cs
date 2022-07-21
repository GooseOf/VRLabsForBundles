using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBulb : ElectricDevice
{
    [SerializeField] private GameObject lightObject;
    [SerializeField] private Light lighting;
    [SerializeField] private float lightingMultiplyer;
    [SerializeField] private float neededVoltage;

    protected override void OnVoltageChange()
    {

        if(Voltage >= neededVoltage)
        {
            lightObject.SetActive(true);
            lighting.intensity = Amperage * lightingMultiplyer;
        }
        else
        {
            lightObject.SetActive(false);
        }
    }
}
