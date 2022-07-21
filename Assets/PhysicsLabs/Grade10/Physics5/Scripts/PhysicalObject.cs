using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalObject : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    void Start()
    {
        //LabWorkPause.physicalObjects.Add(rb);
        //LabWorkPause.physicalObjectsParent.Add(rb.transform.parent.parent);
        rb.Sleep();
    }
}
