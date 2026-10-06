
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerNew : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 3f;
    [SerializeField] private ParticleSystem playerDes;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float jumpBufferTimer = 0.12f;
    [SerializeField] private GameObject run;



    private bool isGrounded;
    private float jumpBufferCounter;
    private Animator animator;
    private Rigidbody2D rb;
    private InputSystem_Actions inputActions;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputActions = new InputSystem_Actions();
        animator = GetComponentInChildren<Animator>();
    }

    private void OnEnable() => inputActions.Enable();
    private void OnDisable() => inputActions.Disable();

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (inputActions.Player.Jump.triggered)
        {
            jumpBufferCounter = jumpBufferTimer;
        }

        jumpBufferCounter -= Time.deltaTime;

        if(isGrounded && jumpBufferCounter > 0f)
        {
            Jump();
            jumpBufferCounter = 0f;
        }

        run.SetActive(isGrounded);
        animator.SetBool("isJumping", !isGrounded);

    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Instantiate(playerDes, transform.position, Quaternion.identity);
        }
    }
}