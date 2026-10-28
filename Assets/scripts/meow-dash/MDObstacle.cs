using UnityEngine;

public class MDObstacle : MonoBehaviour
{
    [SerializeField] private float mass = 5f;
    [SerializeField] private float gravity = 5f;
    private Rigidbody2D rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MDPlayer"))
        { 
            rb.mass = mass;
            rb.gravityScale = gravity;
        }
    }
}
