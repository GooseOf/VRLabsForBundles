using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableRow : MonoBehaviour
{
    public List<string> Columns { get { return columns; } }
    private List<string> columns = new List<string>();
    [SerializeField] private TableColumn columnSample;
    [SerializeField] private Transform tr;

    public void Initialize(List<string> columns)
    {
        this.columns = columns;
        for(int i = 0; i < columns.Count; i++)
        {
            var newColumn = Instantiate(columnSample, tr);
            newColumn.Display.text = columns[i];
        }
    }
}
