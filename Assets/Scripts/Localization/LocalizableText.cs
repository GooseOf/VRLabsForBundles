using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalizableText : MonoBehaviour
{
    [SerializeField] private Text display;
    [SerializeField] private TextLocalization localization;

    private void Start()
    {
        if (LanguageSingletone.CurrentLanguage == Language.Rus)
            display.text = localization.Rus;
        else
            display.text = localization.Eng;
    }
}
