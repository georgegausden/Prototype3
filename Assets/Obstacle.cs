using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 1f;  // speed at which the plane moves down
    private int previousCoinCount = 0;  // the number of coins collected in the previous frame
    private PickUpCoin pickupCoinsScript;  // reference to the PickUpCoins script
    public LightController lightController;  // reference to the Lightcontroller script
    private bool lightIsOffTriggered = false;  // flag to track if the lightIsOff variable was triggered

    void Start()
    {
        pickupCoinsScript = FindObjectOfType<PickUpCoin>();  // find the PickUpCoins script in the scene
    }

    void Update()
    {
        if (lightController.lightIsOff == true)
        {
            int currentCoinCount = pickupCoinsScript.coins;  // get the current number of coins collected from the PickUpCoins script

            if (currentCoinCount > previousCoinCount)
            {
                transform.position -= new Vector3(0f, speed, 0f);  // move the plane down by the speed amount
                previousCoinCount = currentCoinCount;  // update the previous coin count to the current coin count
            }
        }
        
    }
}
