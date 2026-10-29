using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MDWorldManager : MonoBehaviour
{
    private void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("meow-dash");
        }
    }
}
