using UnityEngine;

public class MDObstacle : MonoBehaviour
{
    [SerializeField] private float mass = 7f;
    [SerializeField] private float gravity = 7f;
    private Rigidbody2D rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out MDMovement player))
        {
            if (player.IsDashing) ChangeProperty();
            else other.gameObject.SetActive(false);
        }
        
    }

    private void ChangeProperty()
    {
        rb.mass = Random.Range(2, mass);
        rb.gravityScale = Random.Range(2, gravity);
    }
}
