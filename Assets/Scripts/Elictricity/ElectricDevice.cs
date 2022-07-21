using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricDevice : MonoBehaviour
{
    public float CurrentResistance { get; set; }

    public float Resistance { get { return resistance; } set { resistance = value; } }
    [SerializeField] protected float resistance;

    public float Voltage
    {
        get { return voltage; }
        set
        {
            voltage = value;
            OnVoltageChange();
        }
    }
    protected float voltage;
    public float Amperage
    {
        get { return voltage / CurrentResistance; }
    }

    protected virtual void OnResistanceChange()
    {

    }

    protected virtual void OnVoltageChange()
    {
    }


    private void Start()
    {
        CurrentResistance = resistance;
    }

}
