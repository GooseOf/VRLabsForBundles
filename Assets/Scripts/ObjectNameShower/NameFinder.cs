using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using TMPro;

public class NameFinder : MonoBehaviour
{
    [Header("Raycasting")]
    [SerializeField] private Transform origin;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float raycastingDistance;
    [Header("Info Table")]
    [SerializeField] private GameObject panelGO;
    [SerializeField] private Transform panelTr;
    [SerializeField] private TextMeshProUGUI display;
    [SerializeField] private Transform mainCamera;


    private ObjectInfoHolder lastObject;

    void Update()
    {
        if (Physics.Raycast(origin.position, origin.forward, out RaycastHit hit, raycastingDistance, layerMask))
        {
            ObjectInfoHolder infoHolder = hit.collider.GetComponent<ObjectInfoHolder>();
            Debug.Log("Shar");
            ShowInfoPanel(hit, infoHolder);
        }
        else
        {
            HidePanel();
        }
    }

    public void ReturnLastObjectToStartSettings()
    {
        if (lastObject != null)
        {
            lastObject = null;
        }
    }

    private void ShowInfoPanel(RaycastHit hit, ObjectInfoHolder infoHolder)
    {
        display.text = infoHolder.GetInfo();
        panelGO.SetActive(true);
        panelTr.position = hit.point - (hit.point - mainCamera.position).normalized / 10;
        panelTr.position += new Vector3(0, 0.1f, 0);
        panelTr.LookAt(mainCamera);
    }

    private void HidePanel()
    {
        panelGO.SetActive(false);
    }

}
