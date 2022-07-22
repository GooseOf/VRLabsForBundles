using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValuesManager_P10_8 : MonoBehaviour
{
    [SerializeField] private Ammeter ammeter;
    [SerializeField] private Voltmeter voltmeter;
    [SerializeField] private Resistor resistor;
    [SerializeField] private Battery battery;
    [SerializeField] private Key key;
    [SerializeField] private LightBulb lightBulb;
    [SerializeField] private Diode diode;

    public void OpenCircuit()
    {
        ammeter.Voltage = 0;
        ammeter.CurrentResistance = ammeter.Resistance;

        voltmeter.Voltage = 0;
        voltmeter.CurrentResistance = voltmeter.Resistance;

        resistor.Voltage = 0;
        resistor.CurrentResistance = resistor.Resistance;

        key.Voltage = 0;
        key.CurrentResistance = key.Resistance;

        lightBulb.Voltage = 0;
        lightBulb.CurrentResistance = lightBulb.Resistance;

        diode.Voltage = 0;
        diode.CurrentResistance = diode.Resistance;
    }

    public void AddResistorListener()
    {
        key.OnClose.AddListener(CloseResistorCircuit);
        battery.OnOwnVoltageChange.AddListener(AddVoltageToResistorCircuit);
    }

    public void RemoveResistorListener()
    {
        key.OnClose.RemoveListener(CloseResistorCircuit);
        battery.OnOwnVoltageChange.RemoveListener(AddVoltageToResistorCircuit);
    }

    public void CloseResistorCircuit()
    {
        AddVoltageToResistorCircuit();
    }

    private void AddVoltageToResistorCircuit()
    {
        if (!key.IsClosed)
            return;

        var totalResistance = battery.Resistance + ammeter.Resistance + resistor.Resistance + key.Resistance;
        var amperage = battery.OwnVoltage / totalResistance;
        var voltage = battery.OwnVoltage;

        ammeter.CurrentResistance = totalResistance;
        ammeter.Voltage = voltage;

        voltmeter.Voltage = voltage;
        voltmeter.CurrentResistance = totalResistance;

        resistor.Voltage = voltage;
        resistor.CurrentResistance = totalResistance;

        key.Voltage = voltage;
        key.CurrentResistance = totalResistance;

        List<string> columnsForTable = new List<string>() { Table.RowsCount + "", voltage + "V", (float)(int)(amperage * 1000) / 1000 + "A" };
        Table.AddRow(columnsForTable);
    }

    public void AddLightBulbListener()
    {
        key.OnClose.AddListener(CloseLightBulbCircuit);
        battery.OnOwnVoltageChange.AddListener(AddVoltageToLightBulbCircuit);
    }

    public void RemoveLightBulbListener()
    {
        key.OnClose.RemoveListener(CloseLightBulbCircuit);
        battery.OnOwnVoltageChange.RemoveListener(AddVoltageToLightBulbCircuit);
    }

    public void CloseLightBulbCircuit()
    {
        AddVoltageToLightBulbCircuit();
    }

    private void AddVoltageToLightBulbCircuit()
    {
        if (!key.IsClosed)
            return;

        var totalResistance = battery.Resistance + ammeter.Resistance + lightBulb.Resistance + key.Resistance;
        var amperage = battery.OwnVoltage / totalResistance;
        var voltage = battery.OwnVoltage;


        ammeter.CurrentResistance = totalResistance;
        ammeter.Voltage = voltage;

        voltmeter.CurrentResistance = totalResistance;
        voltmeter.Voltage = voltage;

        lightBulb.CurrentResistance = totalResistance;
        lightBulb.Voltage = voltage;

        key.CurrentResistance = totalResistance;
        key.Voltage = voltage;

        List<string> columnsForTable = new List<string>() { Table.RowsCount + "", voltage + "V", (float)(int)(amperage * 1000) / 1000 + "A" };
        Table.AddRow(columnsForTable);
    }

    public void AddDiodeListener()
    {
        key.OnClose.AddListener(CloseDiodeCircuit);
        battery.OnOwnVoltageChange.AddListener(AddVoltageToDiodeCircuit);
    }

    public void RemoveDiodeListener()
    {
        key.OnClose.RemoveListener(CloseDiodeCircuit);
        battery.OnOwnVoltageChange.RemoveListener(AddVoltageToDiodeCircuit);
    }

    public void CloseDiodeCircuit()
    {
        AddVoltageToDiodeCircuit();
    }


    public void ChangeDiodeResistance(float value)
    {
        diode.Resistance = value;
    }

    private void AddVoltageToDiodeCircuit()
    {
        if (!key.IsClosed)
            return;

        float geometricProgressionQ = 5;
        var totalResistance = battery.Resistance + ammeter.Resistance + diode.Resistance * Mathf.Pow(geometricProgressionQ, battery.OwnVoltage / 2) + key.Resistance;
        var amperage = battery.OwnVoltage / totalResistance;
        var voltage = battery.OwnVoltage;


        ammeter.CurrentResistance = totalResistance;
        ammeter.Voltage = voltage;

        voltmeter.Voltage = voltage;
        voltmeter.CurrentResistance = totalResistance;

        diode.Voltage = voltage;
        diode.CurrentResistance = totalResistance;

        key.Voltage = voltage;
        key.CurrentResistance = totalResistance;

        List<string> columnsForTable = new List<string>() { Table.RowsCount + "", voltage + "V", (float)(int)(amperage * 1000) / 1000 + "A" };
        Table.AddRow(columnsForTable);
    }

    public void AddDiodeListenerAriphmetic()
    {
        key.OnClose.AddListener(CloseDiodeCircuitAriphmetic);
        battery.OnOwnVoltageChange.AddListener(AddVoltageToDiodeCircuitAriphmetic);
    }

    public void RemoveDiodeListenerAriphmetic()
    {
        key.OnClose.RemoveListener(CloseDiodeCircuitAriphmetic);
        battery.OnOwnVoltageChange.RemoveListener(AddVoltageToDiodeCircuitAriphmetic);
    }


    public void CloseDiodeCircuitAriphmetic()
    {
        AddVoltageToDiodeCircuitAriphmetic();
    }
    private void AddVoltageToDiodeCircuitAriphmetic()
    {
        if (!key.IsClosed)
            return;

        float ariphmeticProgressionD = 0.3f;
        var totalResistance = battery.Resistance + ammeter.Resistance + diode.Resistance + ariphmeticProgressionD * battery.OwnVoltage / 2 + key.Resistance;
        var amperage = battery.OwnVoltage / totalResistance;
        var voltage = battery.OwnVoltage;


        ammeter.CurrentResistance = totalResistance;
        ammeter.Voltage = voltage;

        voltmeter.Voltage = voltage;
        voltmeter.CurrentResistance = totalResistance;

        diode.Voltage = voltage;
        diode.CurrentResistance = totalResistance;

        key.Voltage = voltage;
        key.CurrentResistance = totalResistance;

        List<string> columnsForTable = new List<string>() { Table.RowsCount + "", voltage + "V", (float)(int)(amperage * 1000) / 1000 + "A" };
        Table.AddRow(columnsForTable);
    }

    public void ChangeMultiplyer(float value)
    {
        battery.VoltageMultiplyer = value;
    }
}
