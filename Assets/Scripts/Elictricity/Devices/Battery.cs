using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Battery : ElectricDevice
{
    public float OwnVoltage { get { return ownVoltage * VoltageMultiplyer; } set { ownVoltage = value; } }
    public float VoltageMultiplyer { get; set; } = 1;
    [SerializeField] private float ownVoltage;
    [SerializeField] private TextMeshProUGUI display;

    public UnityEvent OnOwnVoltageChange;

    public void SetVoltage(float value)
    {
        ownVoltage = value * 2;
        display.text = ownVoltage + "V";
        OnOwnVoltageChange.Invoke();
    }
}
