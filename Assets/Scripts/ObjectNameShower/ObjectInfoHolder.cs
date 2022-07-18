using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInfoHolder : MonoBehaviour
{
    [SerializeField] private DeviceName deviceName;

    public string GetInfo()
    {
        switch (LanguageSingletone.CurrentLanguage) {
            case Language.Eng:
                return deviceName.EngName;
            default:
                return deviceName.RusName;
        }
    }
}
