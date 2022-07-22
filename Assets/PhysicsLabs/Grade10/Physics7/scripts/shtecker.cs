using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shtecker : MonoBehaviour
{
    BoxCollider collider;
    Rigidbody rigidbody;

    plug plugChoosen;
    void Start()
    {
        collider = GetComponent<BoxCollider>();
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "WirePlug")
        {
            plugChoosen = other.GetComponent<plug>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "WirePlug")
        {
            plugChoosen = null;
        }
    }

    public void connectShteker()
    {
        if (plugChoosen!=null)
        {
            rigidbody.isKinematic = true;
            collider.enabled = false;

            transform.position = plugChoosen.shteckerPos.position;
            transform.parent = plugChoosen.transform;
            transform.localEulerAngles = Vector3.zero;
        }
    }
}
