using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionEvent : UnityEvent<Collider> {}

public class CollisionsEvents : MonoBehaviour
{
    public CollisionEvent OnTriggerEntered { get; private set; } = new CollisionEvent();
    public CollisionEvent OnCollisionEntered { get; private set; } = new CollisionEvent();
    public CollisionEvent OnTriggerExited { get; private set; } = new CollisionEvent();
    public CollisionEvent OnCollisionExited { get; private set; } = new CollisionEvent();

    private void OnTriggerEnter(Collider other)
    {
        OnTriggerEntered.Invoke(other);
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnCollisionEntered.Invoke(collision.collider);
    }

    private void OnTriggerExit(Collider other)
    {
        OnTriggerExited.Invoke(other);
    }

    private void OnCollisionExit(Collision collision)
    {
        OnCollisionExited.Invoke(collision.collider);
    }
}
