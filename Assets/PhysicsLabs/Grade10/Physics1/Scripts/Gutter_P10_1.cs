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
    [SerializeField] private GameObject startButton;

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
    }

    private void MakeCylinderKinematic(SelectExitEventArgs arg0)
    {
        Cylinder.Rb.isKinematic = true;
    }

    private void BallEntered(Ball_P10_1 ball)
    {
        /*Ball = ball;
        ballLimiter.LimitedTr = Ball.Tr;
        ball.Tr.SetParent(ballLimiter.transform);

        ballLimiter.enabled = true;*/
    }


    private float passedTime;
    private Coroutine stopwatchCoroutine;

    public void StartTrajectory()
    {
        if (Ball == null || Cylinder == null)
            return;

        Ball.Tr.localPosition = ballLimiter.MinValues;
        Ball.Rb.isKinematic = false;
        Ball.Rb.velocity = Vector3.zero;

        stopwatchCoroutine = StartCoroutine(Stopwatch());
        OnTrajectoryStart.Invoke();
        Cylinder.Events.OnTriggerEntered.AddListener(BallTriggerCylinder);
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
            Cylinder.Events.OnTriggerEntered.RemoveListener(BallTriggerCylinder);
            startButton.SetActive(true);

            StopCoroutine(stopwatchCoroutine);

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
