using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DDWorldManager : MonoBehaviour
{
    [SerializeField] private DDObstacleTriangle obstTriangleSpawner;
    [SerializeField] private GameObject restartText;
    public static DDWorldManager Instance;
    public bool isAlive = true;
    private float score;
    private int obstacleDestroyed;
    private float scoreMultiplier = 10f;
    private bool reach100 = false;
    private bool reach200 = false;
    private bool reach300 = false;
    private bool reach400 = false;
    private bool reach500 = false;
    private bool reach600 = false;
    public float Score => score;
    public bool IsAlive => isAlive;

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
        restartText.SetActive(true);
    }
    private void Update()
    {
        if (isAlive)
        {
            score += Time.deltaTime * scoreMultiplier;

            if (score >= 100f && !reach100)
            {
                IncreaseDiff(2f);

                IncreaseObstacleProp(13f, 13f);
                reach100 = true;
            }

            if (score >= 200f && !reach200)
            {
                IncreaseObstacleProp(17f, 17f);

                IncreaseDiff(1.5f);
                reach200 = true;
            }

            if (score >= 300f && !reach300)
            {
                IncreaseDiff(1f);
                IncreaseObstacleProp(23f, 23f);
                reach300 = true;
            }

            if (score >= 400f && !reach400)
            {
                IncreaseObstacleProp(29f, 29f);
                IncreaseDiff(0.8f);
                reach400 = true;
            }

            if (score >= 500f && !reach500)
            {
                IncreaseObstacleProp(33f, 33f);
                IncreaseDiff(0.5f);
                reach500 = true;
            }

        }
        if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("dash-destroy");
        }
    }

    private void IncreaseDiff(float spawnTime)
    {
        obstTriangleSpawner.Diff(spawnTime);
    }

    private void IncreaseObstacleProp(float rotateSpeed, float scaleSize)
    {
        DDObstacle.SetDifficulty(rotateSpeed, scaleSize);
    }

    public void IncreaseObstDes()
    {
        obstacleDestroyed++;
    }

}
