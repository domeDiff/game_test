using System.Threading;
using UnityEngine;

public class DDObstSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstPrefab;
    [SerializeField] private float spawnTimer = 5f;
    [SerializeField] private DDWorldManager worldManager;

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
        int randomIndex = Random.Range(0, obstPrefab.Length);

        Instantiate(obstPrefab[randomIndex], transform.position, Quaternion.identity);

        Debug.Log("Obstacle Spawned");
    }

       public void Diff(float spawnSpeed)
    {
        spawnTimer = spawnSpeed;
        timer = spawnTimer;
    }
}



        