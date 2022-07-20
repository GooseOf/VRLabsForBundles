using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class Lapka : MonoBehaviour
{
    //public GrabInteractableWithoutParentChanging Interactable { get { return interactable; } }
    [SerializeField] private GrabInteractableWithoutParentChanging interactable;
    [SerializeField] private FollowHandByAxis handFollower;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interactable.selectEntered.AddListener(handFollower.SelectEnter);
            interactable.selectEntered.AddListener(handFollower.SelectEnter);
        }        
    }
}
