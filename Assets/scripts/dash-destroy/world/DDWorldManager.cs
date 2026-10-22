using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DDWorldManager : MonoBehaviour
{
    [SerializeField] private DDObstSpawner obstSpawner;
    [SerializeField] private DDObstacle obstacleProperty;
    public bool isAlive = true;
    private float score = 0f;
    private float scoreMultiplier = 10f;
    private bool reach100 = false;
    private bool reach200 = false;
    private bool reach300 = false;
    private bool reach400 = false;
    private bool reach500 = false;

    public bool IsAlive => isAlive;
    public float Score => score;

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

            if(score >= 100f && !reach100)
            {
                IncreaseDiff(3, 25, 3);
                reach100 = true;
            }

            if(score >=200f && !reach200)
            {
                IncreaseDiff(3, 30, 2);
                reach200 = true;
            }

            if (score >= 300f && !reach300)
            {
                IncreaseDiff(3, 30, 1);
                reach300 = true;
            }

            if (score >= 400f && !reach400)
            {
                IncreaseDiff(3, 30, 0);
                reach400 = true;
            }

            if (score >= 500f && !reach500)
            {
                IncreaseDiff(3, 30, 0);
                reach500 = true;
            }


            Debug.Log("score: " + Mathf.FloorToInt(score));

        }
        if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("dash-destroy");
        }
    }

    private void IncreaseDiff(int spawnTime, float rotateSpeed, int diffSpawnIndex)
    {
        obstSpawner.Diff(spawnTime, diffSpawnIndex);
        obstacleProperty.IncreaseDiff(rotateSpeed);
    }
}
