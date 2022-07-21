using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class shootSphere : MonoBehaviour
{
    InputDevice targetDevice;
    public float force;
    public bool isCharged;
    public bool choosen;

    public Transform sphereStartPos;
    public Transform _sphere;
    public Transform dulo;
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

    void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerButtonValue);
        if (triggerButtonValue > 0.9f && isCharged && transform.parent == null)
        {
            Debug.Log("shooted");
            _sphere.position = sphereStartPos.position;
            _sphere.gameObject.SetActive(true);
            _sphere.GetComponent<Rigidbody>().AddForce(dulo.right * force);

            sphereStartPos.gameObject.SetActive(false);

            isCharged = false;
        }
    }



}
