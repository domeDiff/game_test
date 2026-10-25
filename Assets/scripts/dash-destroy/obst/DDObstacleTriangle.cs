using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DDObstacleTriangle : MonoBehaviour
{
    [SerializeField] private GameObject obstPrefab;
    [SerializeField] private float spawnTimer = 3f;
    [SerializeField] private DDWorldManager worldManager;


    [SerializeField] private float timer;
    public float SpawnTimer => spawnTimer;

    private void Update()
    {
        if (!worldManager.IsAlive)
            return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnObstacle();
            timer = spawnTimer;
        }
    }

    private void SpawnObstacle()
    {

        Instantiate(obstPrefab, transform.position, Quaternion.identity);

        Debug.Log("Obstacle Spawned");

    }

    public void Diff(float spawnSpeed)
    {
        spawnTimer = spawnSpeed;
        timer = spawnTimer;
    }
}
