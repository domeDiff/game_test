using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
    }
}
