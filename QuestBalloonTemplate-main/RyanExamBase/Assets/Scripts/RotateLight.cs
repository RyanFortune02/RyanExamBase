using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLight : MonoBehaviour
{
    // This variable controls the speed of the rotation.
    public float rotationSpeed = 180f; // Degrees per minute

    void Update()
    {
        // Calculate the rotation for this frame
        float rotationThisFrame = rotationSpeed * Time.deltaTime;

        // Apply the rotation around the Y-axis
        transform.Rotate(0, rotationThisFrame, 0);
    }
}
