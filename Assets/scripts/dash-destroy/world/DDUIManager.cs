using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class DDUIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text obstDesText;

    private void Update()
    {

        int score = Mathf.FloorToInt(DDWorldManager.Instance.Score);
        scoreText.text = "Score: " + score.ToString("D3");

        int obstDestroyed = DDWorldManager.Instance.ObstacleDestroyed;
        obstDesText.text = "Destroyed: " + obstDestroyed.ToString("D4");
    }
}
