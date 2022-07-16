using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrBPositionFollowEnabler : MonoBehaviour
{
    [SerializeField] private Transform TrB;
    [SerializeField] private DistanceDisplayer highDisplay;
    [SerializeField] private DistanceDisplayer lengthDisplay;
    [SerializeField] private Stopwatch stopwatch;
    public bool spherePos;

    private void Start()
    {
        //highDisplay = transform.parent.parent.GetChild(3).GetComponent<DistanceDisplayer>();
        //lengthDisplay = transform.parent.parent.GetChild(4).GetComponent<DistanceDisplayer>();
        //stopwatch = FindObjectOfType<Stopwatch>();
        //TrB = transform.parent.parent.GetChild(2);        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        spherePos = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (spherePos)
        {
            spherePos = false;
            highDisplay.StartDisplayingDistance();
            lengthDisplay.StartDisplayingDistance();
            AddRowToTable();
        }
    }
    private void Update()
    {
        if (spherePos)
        {
            TrB.position = transform.position;
        }
    }
    private void AddRowToTable()
    {
        double time = Math.Round(stopwatch.MeasuredTime, 2);
        double High = Math.Round(highDisplay.High, 3);
        double Length = Math.Round(lengthDisplay.Length, 3);
        List<string> columns = new List<string>() { High + "ì", time + "c", Length + "ì" };
        Table.AddRow(columns);
    } 
}
