using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] private TMP_Text scoreText;

    [Header("Game Over")]
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text finalScoreText;

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }
    private void Update()
    {
        if (GameManager.Instance.isGameOver)
        {
            ShowGameOver();
            return;
        }

        scoreText.text = "SCORE: " + scoreManager.Instance.score.ToString("D4");
    }

    private void ShowGameOver()
    {
        gameOverPanel.SetActive(true);

        finalScoreText.text = "SCORE: " + scoreManager.Instance.score.ToString("D4");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("main_menu");
    }
}
