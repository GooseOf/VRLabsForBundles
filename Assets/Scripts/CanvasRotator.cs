using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRotator : MonoBehaviour
{
    [SerializeField] private Transform tr;
    private Transform camTr;

    private void Start()
    {
        camTr = Camera.main.transform;
    }

    private void Update()
    {
        tr.LookAt(camTr);
    }
}
