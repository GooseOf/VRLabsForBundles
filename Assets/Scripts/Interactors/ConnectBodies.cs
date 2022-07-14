using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ConnectBodies : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;

    public void Connect(SelectEnterEventArgs args)
    {
        if(args.interactableObject.transform.TryGetComponent<Joint>(out Joint joint))
        {
            joint.connectedBody = rb;
            rb.isKinematic = true;
            StartCoroutine(ReturnNoneKinematic());
        }
    }

    private IEnumerator ReturnNoneKinematic()
    {
        yield return null;
        rb.isKinematic = false;
    }

    public void Disconnect(SelectExitEventArgs args)
    {
        if(args.interactableObject.transform.TryGetComponent<Joint>(out Joint joint))
        {
            joint.connectedBody = null;
        }
    }
}
