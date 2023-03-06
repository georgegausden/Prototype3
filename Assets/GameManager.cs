using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TimerController timerController; // Reference to the TimerController script

    private void Update()
    {
        if (timerController.isGameOver)
        {
            RestartGame();
        }
    }

    private void RestartGame()
    {
        // Reduce the total time by 10 units
        timerController.totalTime -= 10f;
        // Load the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
