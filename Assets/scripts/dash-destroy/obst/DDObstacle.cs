
using TMPro;
using UnityEngine;

public class DDObstacle : MonoBehaviour
{
    // Shared difficulty values, read by every obstacle when it spawns
    public static float RotationSpeed = 10f;
    public static float ShrinkRate = 10f;

    [SerializeField] private GameObject diffInc;

    public static void SetDifficulty(float rotateSpeed, float shrinkRate)
    {
        DDWorldManager.Instance.DiffIncTxt();
        RotationSpeed = rotateSpeed;
        ShrinkRate = shrinkRate;
    }

    public static void ResetDifficulty()
    {
        RotationSpeed = 10f;
        ShrinkRate = 10f;
    }

    [SerializeField] private float minScale = 0.2f;

    private GameObject player;
    private float rotationSpeed;
    private float shrinkRate;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("DDPlayer");

        // Snapshot the current difficulty, so obstacles already on screen don't change mid-life
        shrinkRate = ShrinkRate;
    }

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
        rotationSpeed = Random.Range(-RotationSpeed, RotationSpeed);
    }

    private void Update()
    {
        if (player == null) return;

        if (transform.localScale.x > minScale)
        {
            transform.localScale -= shrinkRate * Time.deltaTime * Vector3.one;

            if (transform.localScale.x < 0.3f)
            {
                Destroy(gameObject);
                return;
            }
        }

        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}