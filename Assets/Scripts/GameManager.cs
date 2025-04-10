using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private TextMeshProUGUI scoreText;

    private int score;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        gameOverCanvas.SetActive(false);
        Time.timeScale = 1f;
        score = 0;
        DisplayScore();
    }

    private void DisplayScore()
    {
        scoreText.text = score.ToString();
    }

    public void GameOver()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void AddScore()
    {
        score++;
        DisplayScore();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
