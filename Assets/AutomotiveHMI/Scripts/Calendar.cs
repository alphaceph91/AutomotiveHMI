using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Calendar : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text currentDate;
    void Update()
    {
        string date = System.DateTime.UtcNow.ToLocalTime().ToString("dd/MM/yyyy");
        currentDate.text = date;
    }
}
