using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[Serializable]
public class Tip
{
    [Header("Tips")]
    public string text;
    [HideInInspector]
    public string header;
    [HideInInspector]
    public AudioClip[] audioTips;

    [Header("Events")]
    public UnityEvent startingEvent;
    public UnityEvent endingEvent;

    [Header("Tech")]
    public int taskScore;
    public bool isStart;

    [Header("Localization")]
    public TaskLocalization localization;
}

public class Tips : MonoBehaviour
{
    [SerializeField] private bool forceStart;
    [SerializeField] private float forceStartingDelay;
    private bool didStart;

    public int currentScore = 0;

    public Tip[] tips;

    [SerializeField] private Text display;
    [SerializeField] private AudioSource audioSource;

    private int currentTaskIndex = 0;
    private Tip currentTask;

    public static Tips Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Tasks duplicated: " + Instance.name + " & " + name);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        LocalizeTasks();

        if (forceStart)
            StartCoroutine(ForceStartDelay(forceStartingDelay));
    }

    private void LocalizeTasks()
    {
        if (LanguageSingletone.CurrentLanguage == Language.Rus)
        {
            for (int i = 0; i < tips.Length; i++)
                LocalizeTask(tips[i], tips[i].localization.Rus);
        }
        else
        {
            for (int i = 0; i < tips.Length; i++)
                LocalizeTask(tips[i], tips[i].localization.Eng);
        }

    }

    private void LocalizeTask(Tip task, TaskForOneLanguage language)
    {
        task.text = language.text;
        task.header = language.header;
        task.audioTips = language.audioTips;
    }

    private IEnumerator ForceStartDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartTasks();
    }

    public void StartTasks()
    {
        if (!didStart)
        {
            didStart = true;

            SearchForStartingTip();

            UpdateTip();
        }
    }

    private void SearchForStartingTip()
    {
        for (int i = 0; i < tips.Length; i++)
        {
            if (tips[i].isStart)
            {
                currentTaskIndex = i;
                break;
            }
        }
    }

    public void TaskComplete()
    {

        if (!didStart)
            return;

        currentScore++;


        if (currentScore == currentTask.taskScore)
        {
            currentTask.endingEvent.Invoke();
            UpdateTip();
        }
    }

    public void GoToTip(int index)
    {
        currentTask.endingEvent.Invoke();
        currentTaskIndex = index;
        UpdateTip();
    }

    private void UpdateTip()
    {
        currentScore = 0;
        currentTask = tips[currentTaskIndex];
        Debug.Log(currentTaskIndex);
        ShowTextTip();
        StartPlayingAudioTips();

        currentTask.startingEvent.Invoke();

        if (currentTaskIndex < tips.Length - 1)
        {
            currentTaskIndex++;
        }
    }

    private void ShowTextTip()
    {
        display.text = currentTask.text;
    }

    private Coroutine lastAudioTipsCoroutine;
    private void StartPlayingAudioTips()
    {
        if (lastAudioTipsCoroutine != null)
            StopCoroutine(lastAudioTipsCoroutine);

        lastAudioTipsCoroutine = StartCoroutine(PlayAudioTips());
    }

    private IEnumerator PlayAudioTips()
    {
        var clips = currentTask.audioTips;
        for (int i = 0; i < clips.Length; i++)
        {
            audioSource.clip = clips[i];
            audioSource.Play();
            yield return new WaitForSeconds(clips[i].length);
        }
    }

}
