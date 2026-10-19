using UnityEngine;

public class DDObstacle : MonoBehaviour
{
    [SerializeField] private float scaleSpeed = 0.5f;
    [SerializeField] private float minScale = 0.2f;

    private Transform player;

    private void Start()
    {
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
    }
}
