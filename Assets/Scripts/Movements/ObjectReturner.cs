using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReturner : MonoBehaviour
{
    [SerializeField] private Transform tr;
    [SerializeField] private Rigidbody rb;
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private void Start()
    {
        initialPosition = tr.position;
        initialRotation = tr.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ObjectsReturner"))
        {
            ReturnToInitialPosition();
        }
    }

    public void ReturnToInitialPosition()
    {
        tr.position = initialPosition;
        tr.rotation = initialRotation;

        if(rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
