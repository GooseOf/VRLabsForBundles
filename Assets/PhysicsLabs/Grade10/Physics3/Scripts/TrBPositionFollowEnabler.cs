using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrBPositionFollowEnabler : MonoBehaviour
{
    [SerializeField] private Transform TrB;
    [SerializeField] private DistanceDisplayer highDisplay;
    [SerializeField] private DistanceDisplayer lengthDisplay;
    [SerializeField] private Stopwatch stopwatch;
    [SerializeField] private Transform sphereRespawn;
    [SerializeField] private Transform sphereCurrent;
    [SerializeField] private Rigidbody rbCurrent;

    public bool spherePos;
    //private bool onBottom;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            spherePos = true;

            onTriggerEnter.Invoke();

            Debug.Log("Trigger");
        }
        if (other.CompareTag("Sea"))
        {
            //onBottom = true;

            spherePos = false;

            ShowDistance();

            AddRowToTable();

            onCollisionEnter.Invoke();

            sphereCurrent.position = sphereRespawn.position;
            rbCurrent.velocity = Vector3.zero;
            rbCurrent.angularVelocity = Vector3.zero;
        }
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        if (spherePos && onBottom)
        {
            spherePos = false;

            ShowDistance();

            AddRowToTable();

            onCollisionEnter.Invoke();

            sphereCurrent.position = sphereRespawn.position;
            Debug.Log("Collision");
        }
        
        
    }*/
    private void ShowDistance()
    {
        highDisplay.StartDisplayingDistance();
        if (lengthDisplay != null) { lengthDisplay.StartDisplayingDistance(); }
    }
    private void Update()
    {
        if (spherePos)
        {
            TrB.position = transform.position + new Vector3(0, -0.1f, 0);
        }
    }
    private void AddRowToTable()
    {
        double time = Math.Round(stopwatch.MeasuredTime, 2);
        double High = Math.Round(highDisplay.High, 3);
        if (lengthDisplay != null)
        {
            double Length = Math.Round(lengthDisplay.Length, 3);
            List<string> columns = new List<string>() { High + "ì", time + "c", Length + "ì" };
            Table.AddRow(columns);
        }
        else
        {
            List<string> columns = new List<string>() { High + "ì", time + "c" };
            Table.AddRow(columns);
        }
        
    }
    [SerializeField] private UnityEvent onTriggerEnter;
    [SerializeField] private UnityEvent onCollisionEnter;
}
