using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeGesture : GestureBase
{

    public EHand m_Hand;
    public EDirection m_Direction;
    [Range(0.1f, 6.0f)]
    public float m_VelocityThreshold = 1.5f;
    public float m_CooldownTime = 0.2f;
    public GameObject Screen1;
    public GameObject Screen2;
    public GameObject Screen3;
    public GameObject Screen4;
    public GameObject Screen5;
    public GameObject Screen6;

    float m_CoolDownLeft = 0.0f;

    void Start()
    {

    }

    void Update()
    {
        if (m_CoolDownLeft > 0.0f)
        {
            m_CoolDownLeft -= Time.deltaTime;
            if (m_CoolDownLeft < 0.0f)
            {
                m_CoolDownLeft = 0.0f;
            }
        }
    }

    bool IsSwiping(ref EDirection a_swipeDirection)
    {
        DetectionManager.DetectionHand detectHand = DetectionManager.Get().GetHand(m_Hand);

        Vector3 velocity = detectHand.GetVelocity();

        velocity = Camera.main.transform.InverseTransformDirection(velocity);

        if (velocity.x >= m_VelocityThreshold) //right
        {
            a_swipeDirection = EDirection.eRight;
            return true;
        }
        else if (velocity.x <= -m_VelocityThreshold)//left
        {
            a_swipeDirection = EDirection.eLeft;
            return true;
        }
        else if (velocity.y >= m_VelocityThreshold) //up
        {
            a_swipeDirection = EDirection.eUpwards;
            return true;
        }
        else if (velocity.y <= -m_VelocityThreshold)//down
        {
            a_swipeDirection = EDirection.eDownwards;
            return true;
        }
        else if (velocity.z >= m_VelocityThreshold) //forward
        {
            a_swipeDirection = EDirection.eOutwards;
            return true;
        }
        else if (velocity.z <= -m_VelocityThreshold)//back
        {
            a_swipeDirection = EDirection.eInWards;
            return true;
        }

        return false;

    }

    public override bool Detected()
    {
        if (DetectionManager.Get().IsHandSet(m_Hand) && m_CoolDownLeft <= 0.0f)
        {

            EDirection swipeDir = EDirection.eRight;

            if (IsSwiping(ref swipeDir))
            {
                if (Screen1.activeSelf && swipeDir == m_Direction)
                {
                    Debug.Log("1");
                    m_CoolDownLeft = m_CooldownTime;
                    Screen1.SetActive(false);
                    Screen2.SetActive(true);
                    return true;
                }

                if (Screen2.activeSelf && swipeDir == m_Direction)
                {
                    Debug.Log("2");
                    m_CoolDownLeft = m_CooldownTime;
                    Screen2.SetActive(false);
                    Screen3.SetActive(true);
                    return true;
                }

                if (Screen3.activeSelf && swipeDir == m_Direction)
                {
                    Debug.Log("3");
                    m_CoolDownLeft = m_CooldownTime;
                    Screen3.SetActive(false);
                    Screen4.SetActive(true);
                    return true;
                }


                if (Screen4.activeSelf && swipeDir == m_Direction)
                {
                    Debug.Log("4");
                    m_CoolDownLeft = m_CooldownTime;
                    Screen4.SetActive(false);
                    Screen5.SetActive(true);
                    return true;
                }

                if (Screen5.activeSelf && swipeDir == m_Direction)
                {
                    Debug.Log("5");
                    m_CoolDownLeft = m_CooldownTime;
                    Screen5.SetActive(false);
                    Screen6.SetActive(true);
                    return true;
                }
            }
        }
        return false;
    }
}