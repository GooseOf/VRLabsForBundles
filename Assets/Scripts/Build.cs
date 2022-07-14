using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BuildValidDevice
{
    public string Name { get { return name; } }
    [SerializeField] private string name;

    public Transform PlaceHolder { get { return placeHolder; } }
    [SerializeField] private Transform placeHolder;
}

public class Build : MonoBehaviour
{
    public BuildValidDevice IsValidName(string name)
    {
        for (int i = 0; i < validDevices.Count; i++)
        {
            if (validDevices[i].Name == name)
                return validDevices[i];
        }

        return null;
    }

    public List<BuildValidDevice> ValidDevices { get { return validDevices;} }
    [SerializeField] private List<BuildValidDevice> validDevices;
}
