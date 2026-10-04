using System;
using UnityEngine;

public class Obst : MonoBehaviour
{ 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.SetActive(false);

        }
    }
}
