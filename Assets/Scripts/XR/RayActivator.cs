using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class RayActivator : MonoBehaviour
{
    public XRRayInteractor leftInteractor;
    public XRRayInteractor rightInteractor;
    public InteractionLayerMask uiLayerMask;
    public InteractionLayerMask workingLayerMask;

    public float uiRayLength;
    public float workingRayLength;

    public void Activate()
    {
        leftInteractor.maxRaycastDistance = uiRayLength;
        rightInteractor.maxRaycastDistance = uiRayLength;
        leftInteractor.GetComponent<XRInteractorLineVisual>().enabled = true;
        rightInteractor.GetComponent<XRInteractorLineVisual>().enabled = true;
        leftInteractor.interactionLayers = uiLayerMask;
        rightInteractor.interactionLayers = uiLayerMask;
    }

    public void Deactivate()
    {
        leftInteractor.maxRaycastDistance = workingRayLength;
        rightInteractor.maxRaycastDistance = workingRayLength;
        leftInteractor.GetComponent<XRInteractorLineVisual>().enabled = false;
        rightInteractor.GetComponent<XRInteractorLineVisual>().enabled = false;
        leftInteractor.interactionLayers = workingLayerMask; 
        rightInteractor.interactionLayers = workingLayerMask;
    }
}
