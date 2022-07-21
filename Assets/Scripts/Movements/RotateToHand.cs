using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RotateToHand : MonoBehaviour
{
    public Transform Hand { get; set; }
    [SerializeField] private Transform tr;
    [SerializeField] private RotationsLimiter limiter;

    public void SelectEnter(SelectEnterEventArgs args) 
    {
        Hand = args.interactorObject.transform;
    }

    public void SelecExit(SelectExitEventArgs args)
    {
        Hand = null;
    }

    private void Update()
    {
        if(Hand != null)
        {
            var handZeroPos = tr.InverseTransformPoint(Hand.position);
            handZeroPos.z = 0;
            tr.up = handZeroPos;
            limiter.Limit();
        }
    }
}
