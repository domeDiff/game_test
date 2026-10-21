using UnityEngine;
using UnityEngine.InputSystem;

public class DDPlayerDestroy : MonoBehaviour
{
    private DDWorldManager worldManager;

    private GameObject player;
    [SerializeField] private ParticleSystem des;
    private void Awake()
    {
        worldManager = FindAnyObjectByType<DDWorldManager>();
        player = GameObject.FindGameObjectWithTag("DDPlayer");
        des = player.GetComponent<ParticleSystem>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DDPlayer"))
        {
            player.SetActive(false);
            Instantiate(des, transform.position, Quaternion.identity);
            Debug.Log("des");

            worldManager.Death();

        }
    }
}
