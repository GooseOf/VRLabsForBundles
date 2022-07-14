using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Retainer : MonoBehaviour
{
    [SerializeField] private Transform retainPoint;
    [SerializeField] private string[] validTags;

    public UnityEvent OnRetained;
    public UnityEvent OnUnRetained;

    private Collider currentRetainedObject;

    private void OnTriggerEnter(Collider other)
    {
        bool doesCompareTag = Array.IndexOf(validTags, other.tag) != -1;
        if (doesCompareTag)
        {
            other.transform.position = retainPoint.position;

            currentRetainedObject = other;
            OnRetained.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other == currentRetainedObject)
        {
            OnUnRetained.Invoke();
        }
    }
}
