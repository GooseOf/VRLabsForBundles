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
        Debug.Log(devices.Count);
    }

    void Update()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerButtonValue);
        if (triggerButtonValue > 0.9f && isCharged && transform.parent == null)
        {
            Debug.Log("shooted");

            _sphere.GetComponent<Rigidbody>().velocity = Vector3.zero;
            _sphere.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

            _sphere.position = sphereStartPos.position;
            _sphere.eulerAngles = Vector3.zero;
            _sphere.gameObject.SetActive(true);
            _sphere.GetComponent<sphere>().shooted = true;
            _sphere.GetComponent<Rigidbody>().AddForce(dulo.right * (force + Random.RandomRange(0,20)));
            GetComponent<AudioSource>().Play();

            sphereStartPos.gameObject.SetActive(false);

            isCharged = false;
        }
    }



}
