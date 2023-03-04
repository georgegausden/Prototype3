using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private TimerController timerController;

    private void Start()
    {
        timerController = FindObjectOfType<TimerController>();
    }

    private void Update()
    {
        if (timerController.isGameOver)
        {
            RestartGame();
        }
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
