using UnityEngine;
using UnityEngine.SceneManagement;

public class MDOutOfBounds : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out MDMovement player))
        {
            SceneManager.LoadScene("meow-dash");
        }
    }
}
