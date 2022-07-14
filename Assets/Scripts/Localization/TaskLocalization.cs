using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TaskForOneLanguage
{
    public string text;
    public string header;
    public AudioClip[] audioTips;
}

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Task")]
public class TaskLocalization : ScriptableObject
{
    public TaskForOneLanguage Rus;
    public TaskForOneLanguage Eng;
}
