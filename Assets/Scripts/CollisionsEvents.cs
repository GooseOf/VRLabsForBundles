using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class CollisionEvent : UnityEvent<Collider> {}

public class CollisionsEvents : MonoBehaviour
{
    [SerializeField] private Collider[] expectedColliders;
    public CollisionEvent OnTriggerEntered { get { return onTriggerEntered; } }
    [SerializeField] private CollisionEvent onTriggerEntered;
    public CollisionEvent OnCollisionEntered { get { return onCollisionEntered; } }
    [SerializeField] private CollisionEvent onCollisionEntered;
    public CollisionEvent OnTriggerExited { get { return onTriggerExited; } }
    [SerializeField] private CollisionEvent onTriggerExited;
    public CollisionEvent OnCollisionExited { get { return onCollisionExited; } }
    [SerializeField] private CollisionEvent onCollisionExited;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other + " " + expectedColliders[0]);
        if (IsExpectedCollider(other))
            OnTriggerEntered.Invoke(other);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (IsExpectedCollider(collision.collider))
            OnCollisionEntered.Invoke(collision.collider);
    }

    private void OnTriggerExit(Collider other)
    {
        if (IsExpectedCollider(other))
            OnTriggerExited.Invoke(other);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (IsExpectedCollider(collision.collider))
            OnCollisionExited.Invoke(collision.collider);
    }

    public bool IsExpectedCollider(Collider collider)
    {
        bool isExpected = true;
        if (expectedColliders != null)
            if (expectedColliders.Length > 0)
                if (Array.IndexOf(expectedColliders, collider) == -1)
                    isExpected = false;

        return isExpected;
    }
}
