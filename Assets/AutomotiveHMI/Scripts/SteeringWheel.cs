using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ANR
{
    public class SteeringWheel : MonoBehaviour
    {
        #region Properties

        // maximum steer angle in degrees
        [SerializeField] private float maxAngle = 45;

        // wheel collider as reference for the steering angle
        [SerializeField] public WheelCollider wheelCollider;

        // current steering wheel angle in degrees
        private float currentAngle = 0;

        // automatic driving using wheel collider as reference
        float targetAngle = 0.0f;

        // makes the interpolation faster when the input is pressed down
        private float interpolationSpeed = 0.05f;

        // event listeners
        private UnityAction<string> eventListenerTOR;

        private int currentForce = 0;

        #endregion

        void Update()
        {
            // automatic driving using wheel collider as reference
            targetAngle = wheelCollider.steerAngle * 1.0f;
            // makes the interpolation faster when the input is pressed down
            interpolationSpeed = 0.05f;
            // smoothly sets the current angle based on the input
            currentAngle = Mathf.Lerp(currentAngle, targetAngle, interpolationSpeed);
            // sets the steering wheel angle
            transform.localEulerAngles = Vector3.back * Mathf.Clamp(currentAngle, -maxAngle, maxAngle);

            if (Math.Abs(currentAngle - targetAngle) < 0.001f)
            {
                // rotate steering wheel (< 0: rotate cw, > 0: rotate ccw)
                // approx. force necessary to turn the steering wheel
                int force = (int)((targetAngle * 2 - currentAngle * 2) * -2.0f) + (targetAngle < 0 ? 6 : -6);
                //Debug.Log("force: " + force);
                currentForce = force;
            }
        }

        #region EventManager
        #endregion
    }
}