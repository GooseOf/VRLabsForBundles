using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FollowHandByAxis : MonoBehaviour
{
    [SerializeField] private Transform trToCheck;
    public Transform TrToMove { get { return trToMove; } set { trToMove = value; } }
    [SerializeField] private Transform trToMove;

    [SerializeField] private TranslateLimiter limiter;
    public Transform Hand { get; set; }

    private void Update()
    {
        if(Hand != null)
        {
            TrToMove.position = Hand.position;
            limiter.Clamp();
        }
    }

    public void SelectEnter(SelectEnterEventArgs args)
    {
        Hand = args.interactorObject.transform;
    }

    public void SelectExit(SelectExitEventArgs args)
    {
        Hand = null;
    }
}
