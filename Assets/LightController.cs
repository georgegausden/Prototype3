using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public float rotationAmount = 1f;  // amount to reduce the x rotation by
    public bool lightIsOff = false;   // set to true once the x rotation reaches 0
    private int previousCoinCount = 0;  // the number of coins collected in the previous frame
    private PickUpCoin pickupCoinsScript;  // reference to the PickUpCoins script

    void Start()
    {
        pickupCoinsScript = FindObjectOfType<PickUpCoin>();  // find the PickUpCoins script in the scene
    }

    void Update()
    {
        int currentCoinCount = pickupCoinsScript.coins;  // get the current number of coins collected from the PickUpCoins script

        if (currentCoinCount > previousCoinCount)
        {
            transform.Rotate(-rotationAmount, 0f, 0f);  // reduce the x rotation of the object by the rotation amount
            previousCoinCount = currentCoinCount;  // update the previous coin count to the current coin count

            if (transform.rotation.eulerAngles.x <= 0f)
            {
                lightIsOff = true;  // set the lightIsOff variable to true if the x rotation reaches 0 or below
            }
        }
    }
}
