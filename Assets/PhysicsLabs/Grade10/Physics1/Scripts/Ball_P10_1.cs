using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Ball_P10_1 : MonoBehaviour
{
    public Rigidbody Rb { get { return rb; } }
    [SerializeField] private Rigidbody rb;
    public Transform Tr { get { return tr; } }
    [SerializeField] private Transform tr;
}
