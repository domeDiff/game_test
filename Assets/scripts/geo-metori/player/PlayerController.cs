using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private bool jumpPressed = false;
    private Rigidbody2D rb;
    private InputSystem_Actions inputActions;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputActions = new InputSystem_Actions();
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
        if (inputActions.Player.Jump.triggered)
        {
            jumpPressed = true;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);

        if(jumpPressed)
        {
            rb.AddForce(Vector2.up * 3f, ForceMode2D.Impulse);
        }

        jumpPressed = false;
    }
}
