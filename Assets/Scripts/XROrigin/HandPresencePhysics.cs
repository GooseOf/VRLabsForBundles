using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPresencePhysics : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform thisTr;
    [SerializeField] private Rigidbody rb;

    private Collider[] handColliders;
    private void Start()
    {
        handColliders = GetComponentsInChildren<Collider>();
    }
    public void EnableColliders()
    {
        foreach (var collider in handColliders)
        {
            collider.enabled = true;
        }
    }
    public void EnableHandColliderDelay(float delay)
    {
        Invoke("EnableColliders", delay);
    }
    public void DisableColliders()
    {
        foreach (var collider in handColliders)
        {
            collider.enabled = false;
        }
    }
    
    void FixedUpdate()
    {
        //position
        rb.velocity = (target.position - thisTr.position) / Time.fixedDeltaTime;

        //rotation
        Quaternion rotationDifference = target.rotation *Quaternion.Inverse(thisTr.rotation);
        rotationDifference.ToAngleAxis(out float angleDegree, out Vector3 rotationAxis);

        Vector3 rotationDifferenceDegree = angleDegree * rotationAxis;
        rb.angularVelocity = (rotationDifferenceDegree * Mathf.Deg2Rad/Time.fixedDeltaTime);
    }
}
