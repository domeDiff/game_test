using System.Collections;
using UnityEngine;

public class DDObstacleTriangle : MonoBehaviour
{
    [SerializeField] private GameObject obstPrefab;
    [SerializeField] private DDWorldManager worldManager;

    [Header("Wave")]
    [SerializeField] private float spawnTimer = 3f;
    [SerializeField] private int spawnCount = 2;
    [SerializeField] private float staggerDelay = 0.25f;

    [Header("Placement")]
    [SerializeField] private Transform Center;
    [SerializeField] private float spawnRadius = 2f;
    [SerializeField] private float timer;

    private static readonly Vector2[] Slots =
  {
        new Vector2( 1f,  0f),
        new Vector2( 0.7071068f,  0.7071068f),
        new Vector2( 0f,  1f),
        new Vector2(-0.7071068f,  0.7071068f),
        new Vector2(-1f,  0f),
        new Vector2(-0.7071068f, -0.7071068f),
        new Vector2( 0f, -1f),
        new Vector2( 0.7071068f, -0.7071068f),
    };

    private Vector3 centerPos;
    public float SpawnTimer => spawnTimer;

    private void Start()
    {
        centerPos = Center != null ? Center.position : Vector3.zero;
    }
    private void Update()
    {
        if (!worldManager.IsAlive)
            return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            StartCoroutine(SpawnWave());
            timer = spawnTimer;
        }
    }

    private IEnumerator SpawnWave()
    {
        int count = Mathf.Clamp(spawnCount, 1, Slots.Length);

        int[] order = new int[Slots.Length];
        for (int i = 0; i < order.Length; i++) order[i] = i;
        for (int i = order.Length - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            (order[i], order[j]) = (order[j], order[i]);
        }

        for (int i = 0; i < count; i++)
        {
            if (!worldManager.IsAlive) yield break;

            Vector2 slot = Slots[order[i]];
            Vector3 pos = centerPos + (Vector3)(slot * spawnRadius);
            Instantiate(obstPrefab, pos, Quaternion.identity);

            if (i < count - 1)
                yield return new WaitForSeconds(staggerDelay);
        }

    }
    public void SetWave(float interval, int count, float stagger)
    {
        spawnTimer = interval;
        spawnCount = count;
        staggerDelay = stagger;
    }
}
