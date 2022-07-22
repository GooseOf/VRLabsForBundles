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
    [SerializeField] private bool ignoreExistingColumns;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Table is duplicated");
        }
        else
        {
            Instance = this;
        }

        AddRow(initialColumns);
    }

    public static int RowsCount { get; private set; }

    private List<TableRow> rows = new List<TableRow>();

    [SerializeField] private TableRow rowSample;
    [SerializeField] private Transform rowsParent;

    public RowAddedEvent OnRowAdded { get { return onRowAdded; } }
    [SerializeField] RowAddedEvent onRowAdded = new RowAddedEvent();

    public static void AddRow(List<string> columns)
    {
        if (Instance.ignoreExistingColumns)
            if (DoesRowExist(columns))
            {
                return;
            }

        RowsCount += 1;
        var newRow = Instantiate(Instance.rowSample, Instance.rowsParent);
        newRow.Initialize(columns);
        Instance.rows.Add(newRow);

        Instance.OnRowAdded.Invoke(columns.ToArray());
    }

    public static bool DoesRowExist(List<string> columns)
    {
        // Чтобы обойти начальную строку, с названиями данных, ( например "№" "Длинна" "Время")
        if (Instance.rows.Count < 2)
            return false;

        for (int i = 1; i < Instance.rows.Count; i++)
        {
            // Зачастую в таблицах есть №, чтобы не сравнивать номер записи цикл начинается с 1
            var row = Instance.rows[i];
            bool doesExist = true;
            if (row.Columns.Count == columns.Count)
            {
                for (int j = 1; j < row.Columns.Count; j++)
                {
                    if (row.Columns[j] != columns[j])
                    {
                        doesExist = false;
                        break;
                    }
                }
            }

            if (doesExist)
                return true;
        }

        return false;
    }
}
