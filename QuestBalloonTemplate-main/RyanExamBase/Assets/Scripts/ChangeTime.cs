using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTime : MonoBehaviour

{
    public float dayLength = 120f; // Length of a full day in seconds
    private float currentTime = 0f;
    public float rotationSpeed = 1f; // Adjust as needed
    public float minExposure = 0.2f;
    public float maxExposure = 1f;
    void Update()
    {
        // Update current time based on real time
        currentTime += Time.deltaTime;

        // Wrap around to start of day if time exceeds day length
        if (currentTime > dayLength)
        {
            currentTime -= dayLength;
        }

        // Calculate current time of day as a value between 0 and 1
        float timeOfDay = currentTime / dayLength;
        Debug.Log(timeOfDay);

        // Update lighting and visuals based on time of day
        //UpdateVisuals(timeOfDay);

        UpdateSkyboxRotation(timeOfDay);
    }
    /*
        void UpdateVisuals(float timeOfDay)
        {
            // Example: Adjust directional light intensity and color
            float intensity = Mathf.Lerp(0.2f, 1f, Mathf.Clamp01(1 - Mathf.Abs(timeOfDay - 0.5f) * 2));
            float colorIntensity = Mathf.Lerp(0.6f, 1f, Mathf.Clamp01(1 - Mathf.Abs(timeOfDay - 0.5f) * 2));
            Color color = new Color(colorIntensity, colorIntensity, colorIntensity, 1f);
            RenderSettings.sun.intensity = intensity;
            RenderSettings.sun.color = color;
            Debug.Log(color);

            // Example: Adjust skybox rotation based on time of day
            float rotationSpeed = 1f; // Adjust as needed
            RenderSettings.skybox.SetFloat("_Rotation", timeOfDay * 360 * rotationSpeed);
        }*/

    void UpdateSkyboxRotation(float timeOfDay)
    {
        float rotation = timeOfDay * 360 * rotationSpeed;
        Debug.Log("Rotation: " + rotation); // Debug output
        RenderSettings.skybox.SetFloat("_Rotation", rotation);
        // Adjust skybox rotation based on time of day
        // RenderSettings.skybox.SetFloat("_Rotation", timeOfDay * 360 * rotationSpeed);
        float exposure = Mathf.Lerp(minExposure, maxExposure, Mathf.Clamp01(1 - Mathf.Abs(timeOfDay - 0.5f) * 2));//Clamps value between 0 and 1 and returns value.If the value is negative then zero is returned. If value is greater than one then one is returned.
        RenderSettings.skybox.SetFloat("_Exposure", exposure);
    }

}
