using UnityEngine;
using UnityEngine.UIElements;

public class DDObstacle : MonoBehaviour
{
    [SerializeField] private float scaleSpeed = 0.5f;
    [SerializeField] private float minScale = 0.2f;
    [SerializeField] private float rotationSpeed = .5f;
    private GameObject player;
    private float randomSpeed;

    private void Awake()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

        randomSpeed = Random.Range(-rotationSpeed, rotationSpeed);

        player = GameObject.FindGameObjectWithTag("DDPlayer");
    }

    private void Update()
    {
        if (player == null)
            return;

        if(transform.localScale.x > minScale)
        {
            transform.localScale -= scaleSpeed * Time.deltaTime * Vector3.one;

            if(transform.localScale.x < 0.3f)
            {
                Destroy(gameObject);
            }
        }


        //Rotation
        gameObject.transform.Rotate(0f, 0f, randomSpeed * Time.deltaTime);
    }
}
