using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMainCamera : MonoBehaviour
{
    [SerializeField] private Transform tr;

    private Transform cameraTr;

    private void Start()
    {
        cameraTr = Camera.main.transform;
    }

    private void Update()
    {
        tr.LookAt(cameraTr);
    }
}
