
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 3f;
    [SerializeField] private ParticleSystem playerDes;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    [Header("Visual Spin")]
    [SerializeField] private Transform visual;
    [SerializeField] private float snapSpeed = 720f;


    private bool isGrounded;
    private float visualAngle;
    private float targetAngle;
    private float startAngle;
    private float jumpTimer;
    private float jumpDuration;
    private Rigidbody2D rb;
    private InputSystem_Actions inputActions;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputActions = new InputSystem_Actions();
    }

    private void OnEnable() => inputActions.Enable();
    private void OnDisable() => inputActions.Disable();

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if(inputActions.Player.Jump.triggered && isGrounded)
            Jump();

        UpdateVisualRotation();

    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); 
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;

        startAngle = Mathf.Round(visualAngle / 60f) * 60f;
        targetAngle = startAngle - 60f;

        float launchSpeed = jumpForce / rb.mass;
        float gravity = Mathf.Abs(Physics2D.gravity.y * rb.gravityScale);
        jumpDuration = Mathf.Max(0.05f, 2f * launchSpeed / gravity);
        jumpTimer = 0f;
    }
    
    private void UpdateVisualRotation()
    {
        if(!isGrounded && jumpTimer < jumpDuration)
        {
            jumpTimer += Time.deltaTime;
            float t = Mathf.Clamp01(jumpTimer / jumpDuration);
            visualAngle = Mathf.Lerp(startAngle, targetAngle, t);
        }
        else
        {
            visualAngle = Mathf.MoveTowards(visualAngle, targetAngle, snapSpeed * Time.deltaTime);
        }

        visual.localRotation = Quaternion.Euler(0f, 0f, visualAngle);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
            Instantiate(playerDes, transform.position, Quaternion.identity);
        
    }
}
