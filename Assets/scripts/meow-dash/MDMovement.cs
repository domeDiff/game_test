using UnityEngine;
using UnityEngine.InputSystem;

public class MDMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private float moveSpeed = 5f;


    private bool jump;
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
        if (inputAction.Player.Jump.WasPressedThisFrame())
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);

        if (jump)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }
    }
}
