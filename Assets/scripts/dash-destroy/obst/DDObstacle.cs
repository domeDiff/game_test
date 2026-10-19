using UnityEngine;

public class DDObstacle : MonoBehaviour
{
    [SerializeField] private float scaleSpeed = 0.5f;
    [SerializeField] private float minScale = 0.2f;
    [SerializeField] private float rotationSpeed = .5f;

    [SerializeField] private float randomRotation;
    private Transform player;

    private void Start()
    {
        randomRotation = Random.Range(0, 360);
        gameObject.transform.Rotate(0f,0f,randomRotation);
        player = GameObject.FindGameObjectWithTag("DDPlayer").transform;
    }

    private void Update()
    {
        if (player == null)
            return;

        if(transform.localScale.x > minScale)
        {
            transform.localScale -= Vector3.one * scaleSpeed * Time.deltaTime;
        }

        //Rotation
        gameObject.transform.Rotate(0f, 0f, rotationSpeed);
    }
}
