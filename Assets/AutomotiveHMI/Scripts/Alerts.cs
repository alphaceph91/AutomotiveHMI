using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alerts : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject alert;
    public int time;
    IEnumerator Start()
    {
        yield return new WaitForSecondsRealtime(time);
        alert.gameObject.SetActive(true);
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(1);
            if (alert.gameObject.activeSelf)
            {
                alert.gameObject.SetActive(false);
            }
            else
            {
                alert.gameObject.SetActive(true);
            }
        }
        alert.gameObject.SetActive(false);
    }
}
