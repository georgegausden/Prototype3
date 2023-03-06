using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class LightIntensityController : MonoBehaviour
{
    public Light spotlight;
    public float increaseSpeed = 1f;
    public float decreaseSpeed = 1f;

    private void Update()
    {
        // Check if the user has clicked the mouse button
        if (Input.GetMouseButtonDown(0))
        {
            // Increase the intensity of the spotlight by 1
            spotlight.intensity += increaseSpeed;
        }

        // Decrease the intensity of the spotlight by 1 each frame
        spotlight.intensity -= decreaseSpeed * Time.deltaTime;
    }
}
