using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LocalizableText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI display;
    [SerializeField] private TextLocalization localization;

    private void Start()
    {
        if (LanguageSingletone.CurrentLanguage == Language.Eng)
            display.text = localization.Eng; 
        else
            display.text = localization.Rus;
    }
}
