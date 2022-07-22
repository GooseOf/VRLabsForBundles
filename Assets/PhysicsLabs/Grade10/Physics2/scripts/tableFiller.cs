using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class tableFiller : MonoBehaviour
{
    public Transform table;
    public TextMeshProUGUI[,] tableCells = new TextMeshProUGUI[7,3];

    public pushkaAngle _pushkaAngle;

    public bool firstStep, secondStep;

    public tipsManager _tipsManager;
    void Start()
    {
        Debug.Log("tableFiller");
        for (int i = 0; i < 7; i++)
        {
            Transform column = table.GetChild(i + 1);
            for (int j = 0; j < 3; j++)
            {
                tableCells[i, j] = column.GetChild(j + 1).GetComponent<TextMeshProUGUI>();
            }
        }
    }

    void Update()
    {
        
    }

    public void setDistance(float distance)
    {
        float ugol = _pushkaAngle.ugol;
        if (ugol < 45 && ugol > 0)
        {
            for (int i = 0; i < 3; i++)
            {
                if (tableCells[Mathf.Abs((int)(ugol / 10 - 2)), i].text == "")
                {
                    tableCells[Mathf.Abs((int)(ugol / 10 - 2)), i].SetText(distance.ToString("F2"));
                    break;
                }
            }
        }
        else if (ugol > 45)
        {
            for (int i = 0; i < 3; i++)
            {
                if (tableCells[Mathf.Abs((int)(ugol / 10 - 1)), i].text == "")
                {
                    tableCells[Mathf.Abs((int)(ugol / 10 - 1)), i].SetText(distance.ToString("F2"));
                    break;
                }
            }
        }
        else if (ugol == 45)
        {
            for (int i = 0; i < 3; i++)
            {
                if (tableCells[3, i].text == "")
                {
                    tableCells[3, i].SetText(distance.ToString("F2"));
                    break;
                }
            }
        }
        checkShoots();
    }

    public void checkShoots()
    {
        if (!firstStep)
        {
            bool full = true;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tableCells[i, j].text == "")
                    {
                        full = false;
                    }
                }
            }
            if (full)
            {
                firstStep = true;
                _tipsManager.nextTip();
            }
        }

        if (!secondStep)
        {
            bool full = true;
            for (int i = 4; i < 7; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tableCells[i, j].text == "")
                    {
                        full = false;
                    }
                }
            }
            if (full)
            {
                _tipsManager.nextTip();
            }
        }
    }

}
