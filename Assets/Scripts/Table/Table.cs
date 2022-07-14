using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RowAddedEvent : UnityEvent<string[]>
{

}

public class Table : MonoBehaviour
{
    public static Table Instance;
    [SerializeField] private List<string> initialColumns;
    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("Table is duplicated");
        }
        else
        {
            Instance = this;
        }

        AddRow(initialColumns);
    }

    private List<TableRow> rows = new List<TableRow>();

    [SerializeField] private TableRow rowSample;
    [SerializeField] private Transform rowsParent;

    public RowAddedEvent OnRowAdded { get; private set; } = new RowAddedEvent();

    public static void AddRow(List<string> columns)
    {
        var newRow = Instantiate(Instance.rowSample, Instance.rowsParent);
        newRow.Initialize(columns);
        Instance.rows.Add(newRow);

        Instance.OnRowAdded.Invoke(columns.ToArray());
    }
}
