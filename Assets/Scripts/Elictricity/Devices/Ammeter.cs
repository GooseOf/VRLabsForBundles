using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ammeter : ElectricDevice
{
    [SerializeField] private float maxAmperage;

    [SerializeField] private float minArrowAngle;
    [SerializeField] private float maxArrowAngle;
    [SerializeField] private Transform arrow;
    [Header("UI")]
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private TextMeshProUGUI infoText;
    [SerializeField] private float accuracy;

    protected override void OnResistanceChange()
    {
        ShowAmperage();
    }

    protected override void OnVoltageChange()
    {
        ShowAmperage();
    }

    public void ShowAmperage()
    {
        var percents = Mathf.Clamp(Amperage, 0, maxAmperage) / maxAmperage;

        var differenceAbs = Mathf.Abs(minArrowAngle) + Mathf.Abs(maxArrowAngle);
        
        infoText.text = (float)((int)(Amperage * accuracy)) / accuracy + "A";
        infoPanel.SetActive(true);
        arrow.eulerAngles = new Vector3(arrow.eulerAngles.x, arrow.eulerAngles.y, minArrowAngle + differenceAbs * percents);
    }
}
