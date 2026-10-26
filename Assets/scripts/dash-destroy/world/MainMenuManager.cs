using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText;

    private void Start()
    {
        highScoreText.text = "High Score: " + DDHighScore.HighScore.ToString("D4");
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("dash-destroy");
    }
}
