using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Hand : MonoBehaviour
{
    [SerializeField] private InputDeviceCharacteristics characteristics;
    public Animator Animator { get { return animator; } set { animator = value; } }
    [SerializeField] private Animator animator;
    private InputDevice device;


    private void Start()
    {
        TryGetDevice();
    }

    private void Update()
    {
        SetValues();
    }

    private void SetValues()
    {
        if (!device.isValid)
        {
            TryGetDevice();
        }
        else
        {
            device.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue);
            animator.SetFloat("Trigger", triggerValue);
            device.TryGetFeatureValue(CommonUsages.grip, out float gripValue);
            animator.SetFloat("Grip", gripValue);
        }
    }

    void TryGetDevice()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(characteristics, devices);

        if (devices.Count > 0)
        {
            device = devices[0];
        }
    }
}
