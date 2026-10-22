using System;
using TMPro;
using UnityEngine;

public class DDUIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private DDWorldManager worldManager;

    private void Update()
    {
        if (worldManager == null || scoreText == null)
            return;

        int score = Mathf.FloorToInt(worldManager.Score);
        scoreText.text = "Score: " + score.ToString("D3");
    }
}
