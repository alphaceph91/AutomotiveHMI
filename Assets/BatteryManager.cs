using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class BatteryManager : MonoBehaviour
{
    [SerializeField] private Image BatteryBar;
    public TMP_Text displayText;
    public GameObject alertUI;

    private float currentValue = 100.0f;

    IEnumerator Start()
    {
        while (currentValue >= 0.0f)
        {
            yield return new WaitForSecondsRealtime(5);
            UpdateBattery();
            if (currentValue < 95.0f)
            {
                alertUI.gameObject.SetActive(true);
            }
        }
    }
    void UpdateBattery()
    {
        displayText.text = currentValue.ToString() + "%";
        currentValue -= 1.0f;
        BatteryBar.fillAmount -= 0.01f;
    }
}
