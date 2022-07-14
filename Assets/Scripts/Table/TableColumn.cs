using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableColumn : MonoBehaviour
{
    public Text Display { get { return display; } }
    [SerializeField] private Text display;
}
