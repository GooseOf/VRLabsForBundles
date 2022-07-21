using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Voltmeter : ElectricDevice
{
    [SerializeField] private float maxVoltage;

    [SerializeField] private float minArrowAngle;
    [SerializeField] private float maxArrowAngle;
    [SerializeField] private Transform arrow;
    [Header("UI")]
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private float accuracy;

    protected override void OnVoltageChange()
    {
        ShowVoltage();
    }

    public void ShowVoltage()
    {
        var percents = Mathf.Clamp(Amperage, 0, maxVoltage) / maxVoltage;

        var differenceAbs = Mathf.Abs(minArrowAngle) + Mathf.Abs(maxArrowAngle);

        infoText.text = (float)((int)(Voltage * accuracy)) / accuracy + "V";
        infoPanel.SetActive(true);
        arrow.eulerAngles = new Vector3(arrow.eulerAngles.x, arrow.eulerAngles.y, minArrowAngle + differenceAbs * percents);
    }
}
