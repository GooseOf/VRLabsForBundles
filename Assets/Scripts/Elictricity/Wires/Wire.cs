using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{
    public WirePlug PlugOne { get { return plugOne; } }
    [SerializeField] private WirePlug plugOne;
    public WirePlug PlugTwo { get { return plugTwo; } }
    [SerializeField] private WirePlug plugTwo;

    public void CheckPlugs()
    {
        if(plugOne.IsInSocket && plugTwo.IsInSocket)
        {
            plugOne.DisableInteractions();
            plugTwo.DisableInteractions();
            Tips.Instance.TaskComplete();
        }
    }
}
