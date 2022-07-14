using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class Cylinder_P10_1 : MonoBehaviour
{
    public Transform Tr { get { return tr; } }
    [SerializeField] private Transform tr;

    public Rigidbody Rb { get { return rb; } }
    [SerializeField] private Rigidbody rb;
    public Transform TrToCheckDistance { get { return trToCheckDistance; } }
    [SerializeField] private Transform trToCheckDistance;
    public CollisionsEvents Events { get { return events; } }
    [SerializeField] private CollisionsEvents events;

    public GrabInteractableWithoutParentChanging Interactable { get { return interactable; } }
    [SerializeField] private GrabInteractableWithoutParentChanging interactable;
}
