using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
public class pushkaAngle : MonoBehaviour
{
    InputDevice targetDevice;
    public Vector3 handStartPos=Vector3.zero;
    public Transform hand;
    public float step;

    public bool isHold;

    public Animator animator;

    public float ugol;
    public GameObject canvas;
    public Text ugolTxt;
    public float ugolTimer;

    
    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
    }

    // Update is called once per frame
    void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerButtonValue);
        if (triggerButtonValue > 0.9f && isHold)
        {
            if (handStartPos == Vector3.zero)
            {
                handStartPos = hand.position;
            }
            else
            {
                if(Vector3.Distance(handStartPos, hand.position) > step)
                {
                    if (hand.position.y > handStartPos.y)
                        changeAngle(1);
                    else if (hand.position.y < handStartPos.y)
                        changeAngle(0);

                    handStartPos = hand.position;
                }
            }
        }

        if (ugolTimer > 0)
        {
            canvas.SetActive(true);
        }
        else
        {
            canvas.SetActive(false);
        }
        ugolTimer -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Hand"))
        {
            hand = other.transform;
            isHold = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Hand"))
        {
            other = null;
            isHold = false;
        }
    }

    public void changeAngle(int x)
    {
        ugolTimer = 2f;
        animator.enabled=false;

        if (x == 1)
        {
            if (ugol == 40)
            {
                ugol = 45;
            }
            else if (ugol == 45)
            {
                ugol = 50;
            }
            else if (ugol < 70)
            {
                ugol += 10;
            }
        }
        else if (x == 0)
        {
            if (ugol == 50)
            {
                ugol = 45;
            }
            else if (ugol == 45)
            {
                ugol = 40;
            }
            else if (ugol > 20)
            {
                ugol -= 10;
            }
        }

        if (ugol < 20)
        {
            ugol = 20;
        }
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.z = ugol;
        transform.eulerAngles = rotationVector;

        ugolTxt.text = ugol + "°";

    }



}
