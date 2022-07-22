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
            DisablePlugs();
            Tips.Instance.TaskComplete();
        }
   }

    public void DisablePlugs()
    {
        plugOne.DisableInteractions();
        plugOne.Outline.enabled = false;
        plugTwo.DisableInteractions();
        plugTwo.Outline.enabled = false;
    }

    public void DisableNotConnectedPlugsTotal()
    {
        if (!plugOne.IsInSocket)
        {
            plugOne.MakeOnlyHands();
            plugOne.Outline.enabled = false;
            plugOne.Grab.enabled = false;
        }
        if (!plugTwo.IsInSocket)
        {
            plugTwo.MakeOnlyHands();
            plugTwo.Outline.enabled = false;
            plugTwo.Grab.enabled = false;
        }
    }

    public void EnableNotSelectedPlug()
    {
        if (!plugOne.IsInSocket)
        {
            plugOne.ActivateInteractions();
            plugOne.Outline.enabled = true;
            plugOne.Grab.enabled = true;
        }
        if (!plugTwo.IsInSocket)
        {
            plugTwo.Grab.enabled = true;
            plugTwo.Outline.enabled = true;
            plugTwo.ActivateInteractions();
        }
    }
}
