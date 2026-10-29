using UnityEngine;

public class MDChunkManager : MonoBehaviour
{
    [SerializeField] private Transform[] chunks;
    [SerializeField] private Transform player;
    [SerializeField] private float chunkLength = 60f;   // width of one chunk
    [SerializeField] private float recycleBuffer = 10f; // extra distance past the chunk's end

    private int firstIndex; // oldest chunk (the one furthest behind)

    private void Update()
    {
        Transform first = chunks[firstIndex];

        // assumes the pivot is at the chunk's LEFT edge
        if (player.position.x > first.position.x + chunkLength + recycleBuffer)
        {
            first.position += Vector3.right * (chunkLength * chunks.Length);
            firstIndex = (firstIndex + 1) % chunks.Length;
        }
    }
}