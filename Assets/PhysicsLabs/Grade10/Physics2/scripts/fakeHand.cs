using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fakeHand : MonoBehaviour
{
    public Transform handTransform;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = handTransform.position;
    }
}
