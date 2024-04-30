using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines the balloon physics and user interaction.
/// Initially, the balloon will not be affected by gravity, and its velocity will always be 0.
/// When you grab the balloon and let go of it, it starts to float away.
/// When the balloon floats away, it will rotate to face upright as it moves up.
/// 
/// This script overrides the balloon rigidbody's Use Gravity and Angular Drag properties.
/// 
/// @author Alex Wills
/// @date 28 March, 2024
/// </summary>
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(OVRGrabbable))]
public class BalloonBehavior : MonoBehaviour
{
    [Tooltip("How fast the balloon will float upwards (m/s).")]
    public float m_MaxFloatSpeed = 2.0f;

    [Tooltip("How quickly the balloon will accelerate moving up (m/s^2).")]
    public float m_FloatAcceleration = 8.0f;

    [Tooltip("How quickly the baloon will rotate to be upright when floating (degrees/s).")]
    public float m_RotationSpeed = 50.0f;

    private bool m_IsFloating = false;
    private bool m_IsReadyForRelease = false;

    private Rigidbody m_Rigidbody;
    private OVRGrabbable m_GrabScript;

    private static Quaternion s_UpQuaternion = Quaternion.Euler(Vector3.up);

    // Start is called before the first frame update
    void Start()
    {
        // Override rigidbody values for ballooon physics
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.useGravity = false;
        m_Rigidbody.angularDrag = 30;   // The balloon will resist rotation

        m_GrabScript = GetComponent<OVRGrabbable>();
    }

    void Update()
    {
        if (!m_IsFloating && m_GrabScript.isGrabbed) { // First time grabbing the balloon
            m_IsReadyForRelease = true;
        } else if (m_IsReadyForRelease && !m_GrabScript.isGrabbed && !m_IsFloating) { // First time releasing the balloon
            m_IsFloating = true;
        }
    }

    // FixedUpdate is called every physics frame
    void FixedUpdate()
    {
        if (m_IsFloating) {
            // Rotate a bit closer to facing up each physics frame
            Quaternion targetRot = Quaternion.RotateTowards(transform.rotation, s_UpQuaternion, m_RotationSpeed * Time.fixedDeltaTime);
            transform.rotation = targetRot;

            // Accelerate to the float speed (add some acceleration, then clamp between the negative float speed and positive float speed)
            float newVerticalVelocity = Mathf.Clamp(m_Rigidbody.velocity.y + m_FloatAcceleration * Time.fixedDeltaTime, -m_MaxFloatSpeed, m_MaxFloatSpeed);
            m_Rigidbody.velocity = new Vector3(m_Rigidbody.velocity.x, newVerticalVelocity, m_Rigidbody.velocity.z);
        } else {
            // Do not let the balloons move until they've been grabbed/released
            m_Rigidbody.velocity = Vector3.zero;
        }
    }
}
