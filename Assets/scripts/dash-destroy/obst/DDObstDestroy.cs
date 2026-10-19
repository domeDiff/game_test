using UnityEngine;

public class DDObstDestroy : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DDPlayer"))
        {
            Destroy(prefab);
        }
    }
}
