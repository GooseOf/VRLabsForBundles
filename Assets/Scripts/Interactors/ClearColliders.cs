using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ClearColliders : MonoBehaviour
{
    [SerializeField] private InteractionLayerMask inactiveLayerMask;
    public void ChangeLayer(SelectEnterEventArgs args)
    {
        args.interactableObject.transform.GetComponent<XRBaseInteractable>().interactionLayers = inactiveLayerMask;
    }

}
