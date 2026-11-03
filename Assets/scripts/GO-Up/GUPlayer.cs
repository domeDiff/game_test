using UnityEngine;

public class GUPlayer : MonoBehaviour
{
    [SerializeField] private float floatSpeed = 3f;
    [SerializeField] private float speedMultiplier = 10f;

    private InputSystem_Actions inputActions;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputActions = GetComponent<InputSystem_Actions>();
        
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity =  new Vector2(0f, floatSpeed * speedMultiplier * Time.deltaTime);
    }
}
