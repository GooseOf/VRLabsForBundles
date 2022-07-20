using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WireSocket : MonoBehaviour
{
    private Transform plug;
    [SerializeField] private SocketWithTagCheck socket;

    private void Start()
    {
        socket.selectEntered.AddListener(OnSelectEntered);
    }

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        plug = args.interactableObject.transform;
    }

    public void EnablePlug()
    {
        var plugComp = plug.GetComponent<WirePlug>();
        plugComp.Outline.enabled = true;
        plugComp.ActivateInteractions();

        socket.selectExited.AddListener(DisableSocket);
    }

    public void DisableSocket(SelectExitEventArgs args)
    {
        socket.enabled = false;
        args.interactableObject.transform.GetComponentInChildren<Outline>().enabled = false;
        Tips.Instance.TaskComplete();
    }
}
