using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DistanceDisplayer : MonoBehaviour
{
    [SerializeField] private bool isVertical;
    [SerializeField] private bool isShowLength;
    [SerializeField] private Transform RayDirector;
    [SerializeField] private GameObject go;
    public Transform LenTrA { get { return lengthTrA; } set { lengthTrA = value; } }
    [SerializeField] private Transform lengthTrA;
    public Transform TrA { get { return trA; } set { trA = value; } }
    [SerializeField] private Transform trA;
    public Transform TrB { get { return trB; } set { trB = value; } }
    [SerializeField] private Transform trB;

    [SerializeField] private float multiplyer;
    [SerializeField] private float accuracy;

    [SerializeField] private RectTransform highCanvas;
    [SerializeField] private RectTransform lengthCanvas;

    [SerializeField] private Text displayText;

    [SerializeField] private Vector3 rotationOffset;

    [SerializeField] private float width;

    public float High { get; private set; }
    public float MultiplyedHigh { get; private set; }
    public float Length { get; private set; }

    private Coroutine displayingCoroutine;

    public void StartDisplayingDistance()
    {
        displayingCoroutine = StartCoroutine(DisplayDistance());
        go.SetActive(true);
    }

    public void StopDisplayingDistance()
    {
        if(displayingCoroutine != null)
            StopCoroutine(displayingCoroutine);
    }

    private IEnumerator DisplayDistance()
    {
        while (true)
        {
            if (isShowLength) { ShowLength(); }
            else { ShowHigh(); }
            yield return null;
        }
    }
    public void ShowHigh()
    {
        High = Vector3.Distance(trA.position, trB.position);
        MultiplyedHigh = High * multiplyer;

        if (isVertical)
        {
            highCanvas.position = trA.position;
        }
        else
        {
            highCanvas.position = trA.position;
            highCanvas.right = trB.position;
            highCanvas.Rotate(rotationOffset);
        }
        highCanvas.sizeDelta = new Vector3(High, width);

        displayText.text = (int)(MultiplyedHigh * accuracy) / accuracy + "ì";

        go.SetActive(true);
    }
    private void ShowLength()
    {
        SetLengthTrA();

        Length = Vector3.Distance(lengthTrA.position, trB.position) * multiplyer;

        if (isVertical)
        {
            lengthCanvas.position = lengthTrA.position;
        }
        else
        {
            lengthCanvas.position = lengthTrA.position;
            lengthCanvas.right = trB.position;
            lengthCanvas.Rotate(rotationOffset);
        }
        lengthCanvas.sizeDelta = new Vector3(Length, width);

        displayText.text = (int)(Length * multiplyer * accuracy) / accuracy + "ì";
    }
    private void SetLengthTrA()
    {
        if (Physics.Raycast(RayDirector.position, RayDirector.forward, out RaycastHit hit, 50))
        {
            Debug.Log(hit.transform.name);
            lengthTrA.position = hit.point + new Vector3(0, 0.05f,0);
        }
    }
}
