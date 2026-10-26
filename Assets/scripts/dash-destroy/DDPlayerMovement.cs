using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class DDPlayerMovement : MonoBehaviour
{
    [SerializeField] private float dashDistance = 3f;
    [SerializeField] private float dashSpeed = 5f;
    [Tooltip("Time window to let the player press two keys for a diagonal dash.")]
    [SerializeField] private float inputBufferTime = 0.06f;
    [SerializeField] private ParticleSystem desAnim;
    [SerializeField] private DDWorldManager worldManager;

    private const float InputThreshold = 0.1f;

    private static readonly Vector2[] EightDirections =
    {
        new Vector2( 1f,  0f),                         // 0   E
        new Vector2( 0.7071068f,  0.7071068f),         // 45  NE
        new Vector2( 0f,  1f),                         // 90  N
        new Vector2(-0.7071068f,  0.7071068f),         // 135 NW
        new Vector2(-1f,  0f),                         // 180 W
        new Vector2(-0.7071068f, -0.7071068f),         // 225 SW
        new Vector2( 0f, -1f),                         // 270 S
        new Vector2( 0.7071068f, -0.7071068f),         // 315 SE
    };

    private bool deathAnimPlayed;
    private bool isDashing;

    private bool isBuffering;
    private float bufferTimer;
    private Vector2 bufferedInput;

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
        // Death check first so the animation can actually play
        if (!worldManager.isAlive)
        {
            previousInput = Vector2.zero;
            isBuffering = false;
            return;
        }

        if (isDashing)
        {
            previousInput = Vector2.zero;
            isBuffering = false;
            return;
        }

        Vector2 input = inputActions.Player.Move.ReadValue<Vector2>();
        if (input.sqrMagnitude < InputThreshold * InputThreshold)
            input = Vector2.zero;

        // --- Buffering: collect keys briefly so diagonals can be formed ---
        if (isBuffering)
        {
            // Keep the strongest value per axis seen during the buffer window
            if (Mathf.Abs(input.x) > Mathf.Abs(bufferedInput.x)) bufferedInput.x = input.x;
            if (Mathf.Abs(input.y) > Mathf.Abs(bufferedInput.y)) bufferedInput.y = input.y;

            bufferTimer -= Time.deltaTime;

            if (bufferTimer <= 0f)
            {
                isBuffering = false;
                StartCoroutine(DashMove(Get8Direction(bufferedInput)));
            }

            previousInput = input;
            return;
        }

        bool newDirectionPressed = input != Vector2.zero &&
                                   (previousInput == Vector2.zero || input != previousInput);

        if (newDirectionPressed)
        {
            isBuffering = true;
            bufferTimer = inputBufferTime;
            bufferedInput = input;
        }

        previousInput = input;
    }

    private IEnumerator DashMove(Vector2 direction)
    {
        isDashing = true;

        Vector2 originalPos = rb.position;
        Vector2 targetPos = originalPos + direction * dashDistance;

        // Dash out
        while (Vector2.Distance(rb.position, targetPos) > 0.05f)
        {
            rb.MovePosition(Vector2.MoveTowards(rb.position, targetPos, dashSpeed * Time.fixedDeltaTime));
            yield return new WaitForFixedUpdate();
        }

        rb.position = targetPos;

        // Return to original point
        while (Vector2.Distance(rb.position, originalPos) > 0.05f)
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
        if (angle < 0f) angle += 360f;

        int index = Mathf.RoundToInt(angle / 45f) % 8;
        return EightDirections[index];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DestroyObstacle"))
        {
            DDWorldManager.Instance.IncreaseObstDes();

            ObstacleDeath obstacleDeath = other.GetComponentInParent<ObstacleDeath>();

            if (obstacleDeath != null)
                obstacleDeath.ObjectDestroy();
            else
                Debug.LogWarning("No obst found above: " + other.name, other);
        }

        if (other.CompareTag("DestroyPlayer"))
        {
            DDWorldManager.Instance.Death();
            Instantiate(desAnim, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
