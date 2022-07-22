using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WireSocket : MonoBehaviour
{
    private Transform plugTr;
    private WirePlug plug;
    [SerializeField] private SocketWithTagCheck socket;

    private void Start()
    {
        socket.selectEntered.AddListener(OnSelectEntered);
    }

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        plugTr = args.interactableObject.transform;
        plug = plugTr.GetComponent<WirePlug>();
    }

    public void EnablePlug()
    {
        plug.Outline.enabled = true;
        plug.ActivateInteractions();

        socket.selectExited.AddListener(DisableSocket);
    }

    public void DisableSocket(SelectExitEventArgs args)
    {
        socket.enabled = false;
        socket.selectExited.RemoveListener(DisableSocket);

        plug.SelecExited(args);

        args.interactableObject.transform.GetComponentInChildren<Outline>().enabled = false;
        Tips.Instance.TaskComplete();
    }

    public void DisablePlugs()
    {
        plug.Wire.DisablePlugs();
    }

    public void GiveInactiveTagToNotSelectedPlugs()
    {
        plug.Wire.GiveInactiveTagToNotSelectedPlugs();
    }

    public void OutlineNotSelectedPlugs()
    {
        plug.Wire.OutlineNotSelectedPlugs();
    }

    public void ActivatePlugs()
    {
        plug.Wire.MakeActivteTag();
    }
}
