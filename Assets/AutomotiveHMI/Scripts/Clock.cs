using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clock : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text currentTime;
    void Update()
    {
        string time = System.DateTime.Now.ToLocalTime().ToString("hh:mm:ss tt");
        currentTime.text = time;
    }
}
