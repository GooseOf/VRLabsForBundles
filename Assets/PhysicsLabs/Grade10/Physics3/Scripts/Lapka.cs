using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD

public class Lapka : MonoBehaviour
{
    [SerializeField] private Transform lapka;
    [SerializeField] private Transform lapkaPosition;
=======
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
>>>>>>> 4c991f8ff55f1ba0879da2fcc9ea8e818c56fc7a
}
