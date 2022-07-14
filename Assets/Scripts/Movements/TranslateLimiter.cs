using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateLimiter : MonoBehaviour
{
    public Transform LimitedTr { get { return limitedTr; } set { limitedTr = value; } }
    [SerializeField] private Transform limitedTr;
    public Vector3 MinValues { get { return minValues; } }
    [SerializeField] private Vector3 minValues;
    public Vector3 MaxValues { get { return maxValues; } set { maxValues = value; } }
    [SerializeField] private Vector3 maxValues;

    public Vector3 Difference { get; private set; }
    private void Start()
    {
        Difference = MaxValues - MinValues;
    }

    private void Update()
    {
        Clamp();
    }

    public void Clamp()
    {
        Vector3 currentPosition = LimitedTr.localPosition;
        float limitedX = Mathf.Clamp(currentPosition.x, minValues.x, maxValues.x);
        float limitedY = Mathf.Clamp(currentPosition.y, minValues.y, maxValues.y);
        float limitedZ = Mathf.Clamp(currentPosition.z, minValues.z, maxValues.z);

        LimitedTr.localPosition = new Vector3(limitedX, limitedY, limitedZ);
    }
}
