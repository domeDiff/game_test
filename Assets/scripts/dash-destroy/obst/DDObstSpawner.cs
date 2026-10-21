using System.Threading;
using UnityEngine;

public class DDObstSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstPrefab;
    [SerializeField] private float spawnTimer = 5f;
    [SerializeField] private DDWorldManager worldManager;

    [SerializeField] private int spawnIndex = 0;

    [SerializeField] private float timer;
    public float SpawnTimer => spawnTimer;

    private void Update()
    {
        if (!worldManager.IsAlive)
            return;

        timer -= Time.deltaTime;

        if(timer <= 0f)
        {
            SpawnObstacle();
            timer = spawnTimer;
        }
    }

    private void SpawnObstacle()
    {
        for(int i = 0; i <= obstPrefab[spawnIndex]; i++)
        {
            int randIndex = Random.Range(0, spawnIndex);

            Instantiate(obstPrefab[randIndex], transform.position, Quaternion.identity);

            Debug.Log("Obstacle Spawned");
        }

        
    }

    public void Diff(float spawnSpeed, int obstPrefabLength)
    {
        spawnTimer = spawnSpeed;
        timer = spawnTimer;
    }
}



        