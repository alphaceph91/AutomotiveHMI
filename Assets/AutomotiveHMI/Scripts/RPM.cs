using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RPM : MonoBehaviour
{
    public Rigidbody target;

    public float maxSpeed = 0.0f; //Maximum speed of the target

    public float minSpeedNeedleAngle;
    public float maxSpeedNeedleAngle;

    [Header("UI")]
    public RectTransform needle;

    private float speed = 0.0f;

    private void Update()
    {
        speed = target.velocity.magnitude * 3.6f;
        if (needle != null)
            needle.localEulerAngles =
                new Vector3(0, 0, Mathf.Lerp(minSpeedNeedleAngle, maxSpeedNeedleAngle, speed / maxSpeed));
    }

}
