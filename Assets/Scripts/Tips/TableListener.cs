using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TableListener : MonoBehaviour
{
    public int NeededRowsCount { set { neededRowsCount = value; } }
    [SerializeField] private int neededRowsCount;
    [SerializeField] private int[] parametersIndexToBeDifferent;
    private int rightRowAdded;
    private List<string>[] usedParameters;

    private void Start()
    {
        PrepareListener();
    }

    public void PrepareListener()
    {
        rightRowAdded = 0;

        InitializeUsedParameters();
        Table.Instance.OnRowAdded.AddListener(OnAddedRowToTable);
    }

    private void InitializeUsedParameters()
    {
        usedParameters = new List<string>[parametersIndexToBeDifferent.Length];
        for (int i = 0; i < usedParameters.Length; i++)
        {
            usedParameters[i] = new List<string>();
        }
    }

    private void OnAddedRowToTable(string[] columns)
    {
        if (IsThereUsedValue(columns))
            return;

        AddUsedValues(columns);

        rightRowAdded += 1;
        OnRightRowAdded.Invoke();

        if (rightRowAdded == neededRowsCount)
        {
            Tips.Instance.TaskComplete();
            Table.Instance.OnRowAdded.RemoveListener(OnAddedRowToTable);
            LabEnding.Invoke();
        }
    }

    private bool IsThereUsedValue(string[] columns)
    {
        for (int i = 0; i < parametersIndexToBeDifferent.Length; i++)
        {
            if (usedParameters[i].IndexOf(columns[parametersIndexToBeDifferent[i]]) != -1)
                return true;
        }

        return false;
    }

    private void AddUsedValues(string[] columns)
    {
        for (int i = 0; i < parametersIndexToBeDifferent.Length; i++)
        {
            usedParameters[i].Add(columns[parametersIndexToBeDifferent[i]]);
        }
    }

    [SerializeField] private UnityEvent OnRightRowAdded;
    [SerializeField] private UnityEvent LabEnding;
}
