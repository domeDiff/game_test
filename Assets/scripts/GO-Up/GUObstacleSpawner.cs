using UnityEngine;

public class GUObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float spawnTimer = 5f;
   
    [SerializeField] private float offsetValue = 7f;

    private float timer;
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnTimer)
        {
            Instantiate(prefab, (transform.position + new Vector3(0f, offsetValue, 0f)), Quaternion.identity);
            timer = 0;
        }
    }

}
