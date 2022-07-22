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

    public void GiveInactiveTagToNotSelectedPlugs()
    {
        if (!plugOne.IsInSocket)
        {
            plugOne.tag = "InactivePlug";
        }
        if (!plugTwo.IsInSocket)
        {
            plugTwo.tag = "InactivePlug";
        }
    }

    public void OutlineNotSelectedPlugs()
    {
        if (!plugOne.IsInSocket)
        {
            plugOne.Outline.enabled = true;
        }
        if (!plugTwo.IsInSocket)
        {
            plugTwo.Outline.enabled = true;
        }
    }

    public void MakeActivteTag() 
    {
        plugOne.tag = "WirePlug";
        plugTwo.tag = "WirePlug";
    }
}
