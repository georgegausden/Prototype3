using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float movementSpeed = 1f;  // speed at which the object moves down
    public LightController lightController;  // reference to the XRotationController script
    private bool lightIsOffTriggered = false;  // flag to track if the lightIsOff variable was triggered

    void Update()
    {
        if (lightController.lightIsOff)  // check if the lightIsOff variable in the XRotationController script is true
        {
            if (!lightIsOffTriggered)  // check if lightIsOff was just triggered
            {
                lightIsOffTriggered = true;  // set the flag to true
            }
            else if (lightController.lightIsOff && lightController.lightIsOff != lightIsOffTriggered)  // check if lightIsOff was triggered and the flag has been set
            {
                transform.Translate(0f, -1f, 0f);  // move the object downwards by 1 unit
                lightIsOffTriggered = lightController.lightIsOff;  // update the flag to match the lightIsOff variable
            }
        }
    }
}
