using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DDWorldManager : MonoBehaviour
{
    [SerializeField] private DDObstacleTriangle obstTriangleSpawner;
    public static DDWorldManager Instance;
    public bool isAlive = true;
    private float score;
    private int obstacleDestroyed;
    private float scoreMultiplier = 10f;
    public float Score => score;
    public bool IsAlive => isAlive;

    [Header("Diff")]
    [SerializeField] private float maxScore = 2000f;
    [SerializeField] float cycleTime = 1.0f;
    private const float ObstacleMinScale = 0.3f;

    public int ObstacleDestroyed => obstacleDestroyed;

    private void Awake()
    {
        Instance = this;
        DDObstacle.ResetDifficulty();
    }
    public void Death()
    {
        isAlive = false;
        Debug.Log("final score: " + Mathf.FloorToInt(score));
    }

    private void Update()
    {
        if (isAlive)
        {
            score += Time.deltaTime * scoreMultiplier;

            ApplyDifficulty();
        }

        if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("dash-destroy");
        }
    }

    private void ApplyDifficulty()
    {
        float d = Mathf.SmoothStep(0f, 1f, Mathf.Clamp01(score / maxScore));

        int count = 1 + Mathf.FloorToInt(d * 4.99f);
        float slack = Mathf.Lerp(0.8f, 0.1f, d);
        float perTriangle = cycleTime + slack;

        float lifetime = 0.6f + count * perTriangle;

        float interval = count * perTriangle + Mathf.Lerp(1.0f, 0.2f, d);
        float stagger = Mathf.Lerp(0.5f, 0.25f, d);
        float rotation = Mathf.Lerp(10f, 35f, d);

        obstTriangleSpawner.SetWave(interval, count, stagger);
        DDObstacle.SetDifficulty(rotation, lifetime);
    }

    public void IncreaseObstDes()
    {
        obstacleDestroyed++;
    }
}
