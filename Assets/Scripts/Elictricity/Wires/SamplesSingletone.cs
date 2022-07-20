using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SamplesSingletone : MonoBehaviour
{
    public static SamplesSingletone Instance;

    private void Awake()
    {
        if (Instance != null)
            Debug.LogError("Samples is duplicated " + name + " " + Instance.name);
        else
            Instance = this;
    }

    public static InteractionLayerMask InactiveLayerMask { get { return Instance.inactiveLayerMask; } }
    [SerializeField] private InteractionLayerMask inactiveLayerMask;

    public static InteractionLayerMask ActiveLayerMask { get { return Instance.activeLayerMask; } }
    [SerializeField] private InteractionLayerMask activeLayerMask;
}
