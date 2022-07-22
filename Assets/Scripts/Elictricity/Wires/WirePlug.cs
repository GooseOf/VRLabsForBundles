using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WirePlug : MonoBehaviour
{
    public Wire Wire { get { return wire; } }
    [SerializeField] private Wire wire;
    public XRGrabInteractable Grab { get { return grab; } }
    [SerializeField] private XRGrabInteractable grab;
    public Outline Outline { get { return outline; } }
    [SerializeField] private Outline outline;
    [SerializeField] private Collider[] colliders;



    public bool IsInSocket { get;  private set; }

    public void SelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log("enter");
        if (!args.interactorObject.transform.CompareTag("Hand"))
        {
            IsInSocket = true;

            for(int i = 0; i < colliders.Length; i++)
            {
                colliders[i].enabled = false;
            }

            wire.CheckPlugs();
        }
    }

    public void SelecExited(SelectExitEventArgs args)
    {
        Debug.Log("exit");

        for (int i = 0; i < colliders.Length; i++)
        {
            colliders[i].enabled = true;
        }

        IsInSocket = false;
    }

    public void DisableInteractions()
    {
        grab.interactionLayers = SamplesSingletone.InactiveLayerMask;
    }

    public void ActivateInteractions()
    {
        grab.interactionLayers = SamplesSingletone.ActiveLayerMask;
    }
}

