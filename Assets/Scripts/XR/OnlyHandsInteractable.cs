using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OnlyHandsInteractable : MonoBehaviour
{
    [SerializeField] private XRBaseInteractable interactable;

    private void Start()
    {
        interactable.selectEntered.AddListener(SelectEntered);
        interactable.selectExited.AddListener(SelectExited);
    }

    public void SelectEntered(SelectEnterEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("Hand"))
        {
            interactable.interactionLayers = SamplesSingletone.ActiveLayerMask;
        }
    }

    public void SelectExited(SelectExitEventArgs args)
    {
        if (args.interactorObject.transform.CompareTag("Hand"))
        {
            StartCoroutine(MakeOnlyHandsIfNotConnectedAfterSeconds(0.3f));
        }
    }

    private IEnumerator MakeOnlyHandsIfNotConnectedAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if(!interactable.isSelected)
            interactable.interactionLayers = SamplesSingletone.OnlyHands;
    }
}
