using Unity.VectorGraphics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MDMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.10f;
    [SerializeField] private LayerMask groundLayer;



    private bool wasGrounded;
    private bool hasDoubleJump = true;
    private bool isGrounded;
    private Rigidbody2D rb;
    private InputSystem_Actions inputAction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputAction = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable()
    {
        inputAction.Disable();
    }
    private void Update()
    {
        wasGrounded = isGrounded;

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded && !wasGrounded)
            hasDoubleJump = false;

        if (inputAction.Player.Jump.WasPressedThisFrame())
        {
            Jump();
        }

        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            Reload();
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        if (isGrounded){
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            hasDoubleJump = true;
        }

        else if(hasDoubleJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce-2);
            hasDoubleJump = false;
        }
    }

    private void Reload()
    {
        SceneManager.LoadScene("meow-dash");
    }
}
