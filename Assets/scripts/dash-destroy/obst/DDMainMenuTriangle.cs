using UnityEngine;

public class DDMainMenuTriangle : MonoBehaviour
{
    [SerializeField] float RotationSpeed = 10f;

    private GameObject player;
    private float rotationSpeed;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("DDPlayer");
    }

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
        rotationSpeed = Random.Range(-RotationSpeed, RotationSpeed);
    }

    private void Update()
    {
        if (player == null) return;

       

        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}

