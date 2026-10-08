using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private GameObject[] pipes;


    private void Update()
    {
        if (player.transform.position.x > transform.position.x)
        {
            SpawnPipe();
        }
    }

    private void SpawnPipe()
    {
        int randomIndex = Random.Range(0, pipes.Length);

        GameObject pipe = Instantiate(pipes[randomIndex], transform.position, Quaternion.identity);

        pipe.transform.SetParent(transform.parent);

        Destroy(pipe, 10f); // Destroy the pipe after 10 seconds

        transform.position += new Vector3(5f, 0f, 0f); // Move the spawner to the right for the next pipe
    }

}
