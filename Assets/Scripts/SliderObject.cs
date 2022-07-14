using UnityEngine;
using UnityEngine.Events;


public class SliderObject : MonoBehaviour
{
    public Transform Tr { get { return tr; } set { tr = value; } }
    [SerializeField] private Transform tr;
    [SerializeField] private Axis axis;
    [SerializeField] private float minValue;
    [SerializeField] private float maxValue;
    public UnityEvent OnValueChanged;

    private float deltaValue;
    private float maxValuePlusMin;

    private void Start()
    {
        if (minValue < 0)
            deltaValue = Mathf.Abs(minValue);
        else
            deltaValue = -minValue;

        maxValuePlusMin = maxValue + deltaValue;
    }

    private float prevValue;
    private void Update()
    {
        Value = GetValue();
        Delta = Value - prevValue;
        if (prevValue != Value)
        {
            OnValueChanged.Invoke();
            prevValue = Value;
        }
    }

    public float Value { get; private set; }
    public float Delta { get; private set; }

    public float GetValue()
    {
        float value = 0;
        switch (axis)
        {
            case Axis.X:
                value = ValueX();
                break;
            case Axis.Y:
                value = ValueY();
                break;
            case Axis.Z:
                value = ValueZ();
                break;
        }

        return Mathf.Clamp(value, 0, 1);
    }

    public float ValueX()
    {
        float x = tr.localPosition.x + deltaValue;
        return x / maxValuePlusMin;
    }

    public float ValueY()
    {
        float y = tr.localPosition.y + deltaValue;
        return y / maxValuePlusMin;
    }

    public float ValueZ()
    {
        float z = tr.localPosition.z + deltaValue;
        return z / maxValuePlusMin;
    }
}
