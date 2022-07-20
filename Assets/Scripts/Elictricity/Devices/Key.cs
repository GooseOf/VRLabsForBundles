using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : ElectricDevice
{

    public UnityEvent OnClose;
    public UnityEvent OnOpen;

    public bool IsClosed { get; private set; }
    public void Close()
    {
        if (!IsClosed)
        {
            IsClosed = true;

            OnClose.Invoke();
        }
    }

    public void Open()
    {
        if (IsClosed)
        {
            IsClosed = false;

            OnOpen.Invoke();
        }
    }

    [SerializeField] private GrabInteractableWithoutParentChanging grab;
    [SerializeField] private Outline outline;
    public void ActivateKey()
    {
        grab.enabled = true;
        outline.enabled = true;
    }
}
