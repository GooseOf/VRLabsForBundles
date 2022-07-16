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
    public Cylinder_P10_1 Cylinder { get; set; }

    public bool AcceptCylinder { get; set; }
    
    [Header("Ball")]
    [SerializeField] private TranslateLimiter ballLimiter;
    [SerializeField] private Vector3 ballOffsetCylinder;
    public Ball_P10_1 Ball { get; set; }

    [Header("UI")]
    [SerializeField] private Stopwatch stopwatch;

    [Header("Events")]
    public UnityEvent OnTrajectoryStart;
    public UnityEvent OnTrajectoryStop;
    public UnityEvent OnCylinderHit;
    public UnityEvent OnCylinderPlaced;

    private void OnTriggerEnter(Collider other)
    {
        if (Cylinder == null && AcceptCylinder)
            if (other.TryGetComponent<Cylinder_P10_1>(out Cylinder_P10_1 cylinder))
            {
                CylinderEntered(cylinder);
                OnCylinderPlaced.Invoke();
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
        cylinder.Rb.isKinematic = true;
        cylinder.Interactable.selectExited.AddListener(MakeCylinderKinematic);
        cylinder.Tr.rotation = cylinderLimiter.transform.rotation;

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
        if (Ball != null)
        {
            Ball.Interactable.selectExited.RemoveListener(StartTrajectory);
            StopTrajectory();
            Ball = null;
        }
    }

    private Coroutine accelerationCoroutine;
    private IEnumerator AccelerateBall()
    {
        while (true)
        {
            //Ball.Rb.AddForce(transform.right * 6 * Time.deltaTime);
            yield return null;
        }
    }

    public void StartTrajectory(SelectExitEventArgs args)
    {
        if (Ball == null || Cylinder == null)
            return;

        accelerationCoroutine = StartCoroutine(AccelerateBall());

        Cylinder.Events.OnTriggerEntered.AddListener(BallTriggerCylinder);
        stopwatch.StopWatchReset();
        stopwatch.StopWatchStart();

        OnTrajectoryStart.Invoke();
    }

    private void StopStopwatch()
    {
        stopwatch.StopWatchStop();
    }

    private void StopTrajectory()
    {
        if (Cylinder != null)
            Cylinder.Events.OnTriggerEntered.RemoveListener(BallTriggerCylinder);
        StopStopwatch();

        if(accelerationCoroutine != null)
            StopCoroutine(accelerationCoroutine);

        OnTrajectoryStop.Invoke();
    }

    public void BallTriggerCylinder(Collider collider)
    {
        if (collider.TryGetComponent<Ball_P10_1>(out Ball_P10_1 ball))
        {
            StopTrajectory();

            var distance = (float)(int)(cylinderDistanceDisplayer.MultiplyedHigh * 1000) / 1000 + "ì";
            var time = stopwatch.GetStringTime();
            Table.AddRow(new List<string>() { Table.RowsCount + "", distance, time });

            OnCylinderHit.Invoke();
        }
    }

    public void OnCylinderSliderValueChanged()
    {
        cylinderDistanceDisplayer.ShowHigh();
        ballLimiter.MaxValues = (cylinderLimiter.MinValues + cylinderLimiter.Difference * cylinderSlider.Value) + ballOffsetCylinder;
    }
}
