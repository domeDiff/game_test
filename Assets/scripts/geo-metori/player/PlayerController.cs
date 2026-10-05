using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 3f;
    [SerializeField] private ParticleSystem playerDes;

    private bool isGrounded;
    private Animator animator;
    private Rigidbody2D rb;
    private InputSystem_Actions inputActions;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputActions = new InputSystem_Actions();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }
  
    private void Update()
    {
        IsGrounded();

        if (inputActions.Player.Jump.triggered && isGrounded)
        {
            Jump();
        }

        if(isGrounded)
        {
            animator.SetBool("isJumping", false);
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        animator.SetBool("isJumping", true);
    }

    private void IsGrounded()
    {
        isGrounded = Physics2D.OverlapCircle(transform.position, 0.1f, LayerMask.GetMask("Ground"));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Instantiate(playerDes, transform.position, Quaternion.identity);
        }
    }
}
