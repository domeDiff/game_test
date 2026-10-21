using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DDPlayerController : MonoBehaviour
{
    [SerializeField] private float dashDistance = 3f;
    [SerializeField] private float dashSpeed = 5f;
    [SerializeField] private ParticleSystem desAnim;
    [SerializeField] private DDWorldManager worldManager;
    private bool isDashing;
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
        if (inputActions.Player.Move.WasPressedThisFrame() && !isDashing)
        {
            Vector2 direction = inputActions.Player.Move.ReadValue<Vector2>();

            if(direction != Vector2.zero)
            {
                StartCoroutine(DashMove(direction.normalized));
            }
        }

        if (!worldManager.isAlive)
        {
            Instantiate(desAnim, transform.position, Quaternion.identity);
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
}
