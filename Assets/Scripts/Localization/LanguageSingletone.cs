using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Language
{
    Rus,
    Eng
}

public class LanguageSingletone : MonoBehaviour
{
    [SerializeField] private Language startLanguage;

    private void Awake()
    {
        CurrentLanguage = startLanguage;
    }

    public static Language CurrentLanguage;
}
