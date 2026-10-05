using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Obst : MonoBehaviour
{
    private bool playerDead;
    private float resTimer = .6f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !playerDead)
        {
            playerDead = true;
            
            collision.gameObject.SetActive(false);

            StartCoroutine(ReloadScene());
        }
    }
    
    private IEnumerator ReloadScene()
    {
        yield return new WaitForSeconds(resTimer);

        SceneManager.LoadScene("geo_metori");
    }
}
