using UnityEngine;

public class ObstacleDeath : MonoBehaviour
{
    [SerializeField] private float minGravityScale = 3f;
    [SerializeField] private float maxGravityScale = 6f;
    [SerializeField] private float minMass = 1f;
    [SerializeField] private float maxMass = 3f;
    [SerializeField] private float burstForce = 2f;
    [SerializeField] private float spinForce = 10f;
    [SerializeField] private float destroyDelay = 1.9f; 

    private Rigidbody2D[] bodies;
    private bool destroyed;

    private void Awake()
    {
        bodies = GetComponentsInChildren<Rigidbody2D>();
    }

    public void ObjectDestroy()
    {
        if (destroyed) return;   // trigger can fire more than once
        destroyed = true;

        DDObstacle mover = GetComponent<DDObstacle>();
        if(mover != null) mover.enabled = false; ;



        foreach (Rigidbody2D rb in bodies)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = Random.Range(minGravityScale, maxGravityScale);
            rb.mass = Random.Range(minMass, maxMass);

            Vector2 kick = new Vector2(Random.Range(-1f, 1f), Random.Range(0.3f, 1f)).normalized;
            rb.AddForce(kick * burstForce, ForceMode2D.Impulse);

            // Spin
            rb.AddTorque(Random.Range(-spinForce, spinForce), ForceMode2D.Impulse);
        }

        foreach (Collider2D c in GetComponentsInChildren<Collider2D>())
        {
            c.enabled = false;
        }

        Destroy(gameObject, destroyDelay);
    }
}