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

    [SerializeField] private GameObject settingsPanel;

    [SerializeField] private GameObject Title;

    [SerializeField] private GameObject buttonParent;

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
        SceneManager.LoadScene("dash-destroy");

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SettingsButtonOpen()
    {
        buttonParent.SetActive(false);

        Title.SetActive(false);


        settingsPanel.SetActive(true);
    }

    public void SettingsButtonClose()
    {
        buttonParent.SetActive(true);
        Title.SetActive(true);

        settingsPanel.SetActive(false);
    }
}

