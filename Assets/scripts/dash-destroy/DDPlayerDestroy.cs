using UnityEngine;
using UnityEngine.InputSystem;

public class DDPlayerDestroy : MonoBehaviour
{
    private DDWorldManager worldManager;

    private bool isInvincible;
    
    private void Awake()
    {
        worldManager = FindAnyObjectByType<DDWorldManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.root.CompareTag("DDPlayer"))
        {
            if (Keyboard.current.iKey.isPressed)
            {
                isInvincible = true;
            }

            else
            {
                collision.transform.root.gameObject.SetActive(false);

                Debug.Log("des");
            }

            worldManager.Death();

        }
    }
}
