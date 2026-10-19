using UnityEngine;

public class DDPlayerDestroy : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DDPlayer"))
        {
            Destroy(player);
        }
    }
}
