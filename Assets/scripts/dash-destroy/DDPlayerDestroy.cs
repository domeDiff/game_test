using UnityEngine;

public class DDPlayerDestroy : MonoBehaviour
{
    private DDWorldManager worldManager;

    private void Awake()
    {
        worldManager = FindAnyObjectByType<DDWorldManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.root.CompareTag("DDPlayer"))
        {
            worldManager.Death();

            Destroy(collision.transform.root.gameObject);

            Debug.Log("des");
        }
    }
}
