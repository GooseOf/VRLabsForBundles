using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class tipsManager : MonoBehaviour
{
    public List<string> tips;
    public TextMeshProUGUI textMeshPro;
    public int currentTip =1;

    public List<AudioClip> audioTips;
    public AudioSource audioSource;

    public AudioSource buttonSound;

    public GameObject finishPanel;
    public bool isPlaySound;
    void Start()
    {
        textMeshPro.SetText(tips[currentTip]);
        audioSource.clip = audioTips[currentTip];
    }

    void Update()
    {
    }

    public void nextTip()
    {
        currentTip++;
        textMeshPro.SetText(tips[currentTip]);
        audioSource.clip = audioTips[currentTip];
        if (isPlaySound)
        {
            audioSource.Play();
        }
    }

    public void startAudio()
    {
        isPlaySound = true;
        audioSource.Play();
    }
    
    public void ButtonSound()
    {
        buttonSound.Play();
    }
}
