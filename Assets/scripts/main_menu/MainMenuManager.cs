using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup fadePanel;
    [SerializeField] private float fadeDuration = 0.5f;
    [SerializeField] private TMP_Text bestScoreText;

    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject bestScoreGameObject;

    [SerializeField] private GameObject Title;

    [SerializeField] private GameObject buttonParent;

    [SerializeField] private GameObject characterSelectPanel;
    [SerializeField] private GameObject menuCatAnim;

    private void Start()
    {
        bestScoreText.text = "best: " + PlayerPrefs.GetInt("highScore", 0).ToString("D4");
    }
    public void StartGame()
    {
        StartCoroutine(LoadGame());
    }

    private IEnumerator LoadGame()
    {
        fadePanel.blocksRaycasts = true;
        float time = 0f;

        while(time < fadeDuration)
        {
            time += Time.deltaTime;
            fadePanel.alpha = time / fadeDuration;
            yield return null;
        }

        fadePanel.alpha = 1f;
        SceneManager.LoadScene("game");

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenChar()
    {
        characterSelectPanel.SetActive(true);
        menuCatAnim.SetActive(false);
    }

    public void CloseChar()
    {
        characterSelectPanel.SetActive(false);
        menuCatAnim.SetActive(true);
    }

    public void SettingsButtonOpen()
    {
        buttonParent.SetActive(false);
        bestScoreGameObject.SetActive(false);
        Title.SetActive(false);
        menuCatAnim.SetActive(false);

        settingsPanel.SetActive(true);
    }

    public void SettingsButtonClose()
    {
        buttonParent.SetActive(true);
        bestScoreGameObject.SetActive(true);
        Title.SetActive(true);
        menuCatAnim.SetActive(true);

        settingsPanel.SetActive(false);
    }
}

