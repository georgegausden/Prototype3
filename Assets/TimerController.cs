using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour
{
    public float totalTime = 60f; // Total time for the countdown
    public Transform timerDisplay; // Transform of the timer display object
    public TMP_Text timerText; // Text component of the timer display object
    public Image timerImage; // Image component of the timer display object
    public TMP_Text gameOverText; // Text component for game over message
    public TMP_Text coinText; // Text component for the coin count
    public PickUpCoin pickUpCoin; // Reference to the PickUpCoin script


    private float currentTime; // Current time remaining
    public bool isGameOver; // Flag to indicate if the game is over

    void Start()
    {
        currentTime = totalTime;
        isGameOver = false;
    }

    void Update()
    {
        if (isGameOver)
        {
            return;
        }

        // Subtract time from the current time
        currentTime -= Time.deltaTime;

        // Clamp the current time to zero
        currentTime = Mathf.Clamp(currentTime, 0f, totalTime);

        // Update the timer display text
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        // Update the coin count text
        coinText.text = "Coins: " + pickUpCoin.coins.ToString() + "/" + pickUpCoin.coinsToPickUp;

        // Set the position of the timer display in front of the player
        timerDisplay.position = Camera.main.transform.position + Camera.main.transform.forward * 5f;
        timerDisplay.LookAt(Camera.main.transform.position);

        // Check if the timer has reached zero
        if (currentTime == 0f)
        {
            isGameOver = true;
            StartCoroutine(FlashTimer());
            gameOverText.gameObject.SetActive(true);
        }

        if (pickUpCoin.coins >= pickUpCoin.coinsToPickUp && !isGameOver)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            StartCoroutine(FlashTimer());
            gameOverText.gameObject.SetActive(true);
        }

    }

    IEnumerator FlashTimer()
    {
        while (isGameOver)
        {
            timerText.color = Color.red;
            yield return new WaitForSeconds(0.5f);
            timerText.color = Color.white;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
