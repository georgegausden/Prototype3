using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensityController : MonoBehaviour
{
    public Light spotlight;
    public float decreaseSpeed = 1f;

    private void Start()
    {
        // Set the initial spot angle of the spotlight
        spotlight.spotAngle = 30f;
    }

    private void Update()
    {
        // Check if the user has clicked the mouse button
        if (Input.GetMouseButtonDown(0))
        {
            // Increase the spot angle of the spotlight by 1
            spotlight.spotAngle += 1f;
        }

        // Decrease the spot angle of the spotlight by decreaseSpeed each frame
        spotlight.spotAngle -= decreaseSpeed * Time.deltaTime;
    }
}
