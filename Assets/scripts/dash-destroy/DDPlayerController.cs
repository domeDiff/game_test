using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DDPlayerController : MonoBehaviour
{
    [SerializeField] private float dashDistance = 3f;
    [SerializeField] private float dashSpeed = 5f;
    [SerializeField] private ParticleSystem desAnim;
    private bool deathAnimPlayed;
    [SerializeField] private DDWorldManager worldManager;
    private bool isDashing;
    private Vector2 previousInput;
    private InputSystem_Actions inputActions;
    private Rigidbody2D rb;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable() => inputActions.Enable();
    private void OnDisable() => inputActions.Disable();
    private void OnDestroy() => inputActions.Dispose();

    private void Update()
    {
        if(!worldManager.isAlive || isDashing)
        {
            previousInput = Vector2.zero;
            return;
        }

        Vector2 input = inputActions.Player.Move.ReadValue<Vector2>();

        bool newDirectionPressed = input != Vector2.zero && (previousInput == Vector2.zero || input != previousInput);

        if (newDirectionPressed)
        {
            Vector2 direction = Get8Direction(input);
            StartCoroutine(DashMove(direction));
        }

        if (!worldManager.isAlive)
        {
            if (!deathAnimPlayed)
            {
                Instantiate(desAnim, transform.position, Quaternion.identity);
                deathAnimPlayed = true;
            }

            return;
        }
    }


    private IEnumerator DashMove(Vector2 direction)
    {
        isDashing = true;

        Vector2 originalPos = rb.position;
        Vector2 targetPos = originalPos + direction * dashDistance;

        while(Vector2.Distance(rb.position, targetPos) > 0.05f)
        {
            rb.MovePosition(Vector2.MoveTowards(rb.position, targetPos, dashSpeed * Time.fixedDeltaTime));

            yield return new WaitForFixedUpdate();
        }

        rb.position = targetPos;
        
        while(Vector2.Distance(rb.position, originalPos) > 0.05f)
        {
            rb.MovePosition(Vector2.MoveTowards(rb.position, originalPos, dashSpeed * Time.fixedDeltaTime));

            yield return new WaitForFixedUpdate();
        }

        rb.position = originalPos;

        isDashing = false;
    }

    private Vector2 Get8Direction(Vector2 input)
    {
        float angle = Mathf.Atan2(input.y, input.x) * Mathf.Rad2Deg;

        angle = Mathf.Round(angle / 45f) * 45f;

        float radians = angle * Mathf.Deg2Rad;

        return new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)).normalized;
    }
}
