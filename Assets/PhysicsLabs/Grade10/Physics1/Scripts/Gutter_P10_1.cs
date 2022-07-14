using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class Gutter_P10_1 : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [Header("Cylinder")]
    [SerializeField] private SliderObject cylinderSlider;
    [SerializeField] private TranslateLimiter cylinderLimiter;
    [SerializeField] private DistanceDisplayer cylinderDistanceDisplayer;
    [SerializeField] private FollowHandByAxis handFollower;
    [SerializeField] private UnityEvent OnBallHitCylinder;
    public Cylinder_P10_1 Cylinder { get; set; }
    
    [Header("Ball")]
    [SerializeField] private TranslateLimiter ballLimiter;
    [SerializeField] private Vector3 ballOffsetCylinder;
    public Ball_P10_1 Ball { get; set; }

    [Header("UI")]
    [SerializeField] private Text stopwatchDisplay;

    [Header("Events")]
    public UnityEvent OnTrajectoryStart;

    private void OnTriggerEnter(Collider other)
    {
        if (Cylinder == null)
            if (other.TryGetComponent<Cylinder_P10_1>(out Cylinder_P10_1 cylinder))
            {
                CylinderEntered(cylinder);
            }
        if (Ball == null)
            if (other.TryGetComponent<Ball_P10_1>(out Ball_P10_1 ball))
            {
                BallEntered(ball);
            }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<Ball_P10_1>(out Ball_P10_1 ball))
        {
            BallExited(ball);
        }
    }

    private void CylinderEntered(Cylinder_P10_1 cylinder)
    {
        Cylinder = cylinder;

        cylinderSlider.Tr = cylinder.transform;
        cylinderSlider.enabled = true;

        cylinderLimiter.LimitedTr = cylinder.transform;
        cylinder.Tr.SetParent(cylinderLimiter.transform);
        cylinderLimiter.enabled = true;

        cylinderDistanceDisplayer.TrB = Cylinder.TrToCheckDistance;


        handFollower.TrToMove = cylinder.Tr;
        cylinder.Interactable.selectEntered.AddListener(handFollower.SelectEnter);
        cylinder.Interactable.selectExited.AddListener(handFollower.SelectExit);
        handFollower.enabled = true;

        cylinder.Interactable.trackRotation = false;
        cylinder.Interactable.trackPosition = false;

        cylinder.Rb.constraints = RigidbodyConstraints.FreezeRotation;
        cylinder.Interactable.selectExited.AddListener(MakeCylinderKinematic);
        cylinder.Tr.rotation = cylinderLimiter.transform.rotation;

        Cylinder.Events.OnCollisionEntered.AddListener(CylinderHit);

        Cylinder.GetComponent<ConfigurableJoint>().connectedBody = rb;
    }

    private void MakeCylinderKinematic(SelectExitEventArgs arg0)
    {
        Cylinder.Rb.isKinematic = true;
    }

    private void BallEntered(Ball_P10_1 ball)
    {
        Ball = ball;
        Ball.Interactable.selectExited.AddListener(StartTrajectory);
    }

    private void BallExited(Ball_P10_1 ball)
    {
        /*if(ball == Ball)
        {
            Ball.Interactable.selectExited.RemoveListener(StartTrajectory);
            StopTrajectory();

            Ball = null;
        }*/
    }


    private float passedTime;
    private Coroutine stopwatchCoroutine;

    public void StartTrajectory(SelectExitEventArgs args)
    {
        if (Ball == null || Cylinder == null)
            return;

        StopStopwatch();

        stopwatchCoroutine = StartCoroutine(Stopwatch());
        Cylinder.Events.OnTriggerEntered.AddListener(BallTriggerCylinder);
    }

    private void StopStopwatch()
    {
        if (stopwatchCoroutine != null)
            StopCoroutine(stopwatchCoroutine);
    }

    private void StopTrajectory()
    {
        Cylinder.Events.OnTriggerEntered.RemoveListener(BallTriggerCylinder);

        StopStopwatch();
    }

    private IEnumerator Stopwatch()
    {
        passedTime = 0;
        while (true)
        {
            passedTime += Time.deltaTime;
            stopwatchDisplay.text = (float)(int)(passedTime * 1000) / 1000 + "Ñ";
            yield return null;
        }
    }

    private void CylinderHit(Collider collider)
    {
        if (collider.attachedRigidbody != null)
        {
            if (collider.attachedRigidbody.TryGetComponent<Ball_P10_1>(out Ball_P10_1 ball))
            {
                OnBallHitCylinder.Invoke();
            }
        }
    }

    public void BallTriggerCylinder(Collider collider)
    {
        if (collider.TryGetComponent<Ball_P10_1>(out Ball_P10_1 ball))
        {
            StopTrajectory();

            var distance = (float)(int)(cylinderDistanceDisplayer.MultiplyedHigh * 1000) / 1000 + "ì";
            var time = (float)(int)(passedTime * 1000) / 1000 + "c";
            Table.AddRow(new List<string>() { distance, time });
        }
    }

    public void OnCylinderSliderValueChanged()
    {
        cylinderDistanceDisplayer.ShowHigh();
        ballLimiter.MaxValues = (cylinderLimiter.MinValues + cylinderLimiter.Difference * cylinderSlider.Value) + ballOffsetCylinder;
    }
}
