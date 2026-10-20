using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DDWorldManager : MonoBehaviour
{
    [SerializeField] private DDObstSpawner obstSpawner;
    private bool isAlive = true;
    private float score = 0f;
    private float scoreMultiplier = 10f;
    private bool reach100 = false;
    private bool reach200 = false;
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
                IncreaseDiff(3);
                reach100 = true;
            }

            if(score >=200f && !reach200)
            {
                IncreaseDiff(1);
                reach200 = true;
            }


            Debug.Log("score: " + Mathf.FloorToInt(score));

        }
        if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("dash-destroy");
        }
    }

    private void IncreaseDiff(int val)
    {
        obstSpawner.Diff(val);
    }
}
