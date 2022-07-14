using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMoveSlider : MonoBehaviour
{
    [Range(0, 100)][SerializeField] private float LerpSpeed;
    private Vector3 Velocity = new Vector3(0, 0, 0);
    //[SerializeField] private Camera cam;

    [SerializeField] private Transform MovingObj;
    [SerializeField] private Transform Destination;    

    private void FixedUpdate()
    {
        MovingObj.position = Vector3.SmoothDamp(MovingObj.position, Destination.position, ref Velocity, Time.fixedDeltaTime * LerpSpeed);
        //MovingObj.LookAt(MovingObj.position + cam.transform.rotation * Vector3.forward, cam.transform.rotation * Vector3.up);        
    }    
}
