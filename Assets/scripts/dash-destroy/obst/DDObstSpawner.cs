using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class DDObstSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstPrefab;
    [SerializeField] private float spawnTimer = 5f;
    [SerializeField] private DDWorldManager worldManager;

    [SerializeField] private int diffSubVal = 4;

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
        int spawnIndex = Random.Range(0, (obstPrefab.Length-diffSubVal));

        Instantiate(obstPrefab[spawnIndex], transform.position, Quaternion.identity);
        
        Debug.Log("Obstacle Spawned");
        
    }

    public void Diff(float spawnSpeed, int diffSpawnIndex)
    {
        spawnTimer = spawnSpeed;
        timer = spawnTimer;
        diffSubVal = diffSpawnIndex;
    }
}



        