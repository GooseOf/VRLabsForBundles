using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationManager : MonoBehaviour
{
    [SerializeField] private GameObject teleportaionManager;
    [SerializeField] private InputDeviceCharacteristics characteristics;
    private InputDevice device;


    private void Start()
    {
        TryGetDevice();
    }

    private void Update()
    {
        if (device.isValid)
        {
            device.IsPressed(InputHelpers.Button.PrimaryButton, out bool isPressed);
            if (isPressed)
                teleportaionManager.SetActive(true);
            else
                teleportaionManager.SetActive(false);
        }
        else
            TryGetDevice();
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
