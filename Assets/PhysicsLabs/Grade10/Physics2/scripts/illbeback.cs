using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class illbeback : MonoBehaviour
{
    Vector3 nativePos;
    void Start()
    {
        nativePos = transform.position;
    }

    void Update()
    {
        if (transform.position.y < 0)
        {
            transform.position = nativePos;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
}
