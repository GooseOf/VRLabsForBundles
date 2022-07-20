using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationsLimiter : MonoBehaviour
{
    [SerializeField] private Transform tr;
    private Vector3 initialEulers;

    [SerializeField] private Axis axis;

    [SerializeField] private float minValue;
    [SerializeField] private float maxValue;

    private void Start()
    {
        initialEulers = tr.localEulerAngles;
    }

    private void LateUpdate()
    {
        Limit();
    }

    public void Limit()
    {
        switch (axis)
        {
            case Axis.X:
                LimitX();
                break;
            case Axis.Y:
                LimitY();
                break;
            case Axis.Z:
                LimitZ();
                break;
        }
    }

    private void LimitX()
    {
        Vector3 eulers = tr.localEulerAngles;

        eulers.x = (eulers.x > 180) ? eulers.x - 360 : eulers.x;
        eulers.x = Mathf.Clamp(eulers.x, minValue, maxValue);

        tr.localEulerAngles = eulers;
    }

    private void LimitY()
    {
        Vector3 eulers = tr.localEulerAngles;

        eulers.y = (eulers.y > 180) ? eulers.y - 360 : eulers.y;
        eulers.y = Mathf.Clamp(eulers.y, minValue, maxValue);

        tr.localEulerAngles = eulers;
    }

    private void LimitZ()
    {
        Vector3 eulers = tr.localEulerAngles;

        eulers.z = (eulers.z > 180) ? eulers.z - 360 : eulers.z;
        eulers.z = Mathf.Clamp(eulers.z, minValue, maxValue);

        tr.localEulerAngles = eulers;
    }
}
