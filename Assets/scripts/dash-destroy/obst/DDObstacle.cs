using UnityEngine;

public class DDObstacle : MonoBehaviour
{
    public static float RotationSpeed = 10f;
    public static float Lifetime = 3f;   // seconds from spawn until fully shrunk

    public static void SetDifficulty(float rotateSpeed, float lifetime)
    {
        RotationSpeed = rotateSpeed;
        Lifetime = lifetime;
    }

    public static void ResetDifficulty()
    {
        RotationSpeed = 10f;
        Lifetime = 3f;
    }

    [Tooltip("Scale at which the triangle reaches the player and is destroyed (in prefab units)")]
    [SerializeField] private float endScale = 1f;

    private GameObject player;
    private float randomSpeed;
    private float startScale;
    private float lifetime;
    private float elapsed;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("DDPlayer");
    }

    private void Start()
    {
        // Lock in this wave's values at spawn time
        startScale = transform.localScale.x;   // e.g. 45
        lifetime = Mathf.Max(0.1f, Lifetime);

        transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
        randomSpeed = Random.Range(-RotationSpeed, RotationSpeed);
    }

    private void Update()
    {
        if (player == null)
            return;

        elapsed += Time.deltaTime;
        float t = elapsed / lifetime;

        if (t >= 1f)
        {
            Destroy(gameObject);
            return;
        }

        transform.localScale = Vector3.one * Mathf.Lerp(startScale, endScale, t);
        transform.Rotate(0f, 0f, randomSpeed * Time.deltaTime);
    }
}