using System.Collections;
using TMPro;
using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timer;
    public float MeasuredTime { get; private set; }

    private float msec;
    private float sec;
    private float min;

    private void Start()
    {
        StopWatchReset();
    }

    public void StopWatchStart()
    {
        StartCoroutine("StopWatch");
    }
    public void StopWatchStop()
    {
        StopCoroutine("StopWatch");
    }
    public void StopWatchReset()
    {
        MeasuredTime = 0;
        DisplayText("00:00:00");
    }

    public string GetStringTime()
    {

        msec = (int)((MeasuredTime - (int)MeasuredTime) * 100);
        sec = (int)(MeasuredTime % 60);
        min = (int)(MeasuredTime / 60 % 60);

        return string.Format("{0:00}:{1:00}:{2:00}", min, sec, msec);
    }

    private IEnumerator StopWatch()
    {
        while (true)
        {
            MeasuredTime += Time.deltaTime;
            DisplayText(GetStringTime());

            yield return null;
        }
    }

    private void DisplayText(string text)
    {
        if (timer != null)
            timer.text = text;
    }
}
