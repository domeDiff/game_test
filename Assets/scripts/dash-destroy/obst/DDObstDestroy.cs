using System;
using UnityEngine;

public class DDObstDestroy : MonoBehaviour
{
    [SerializeField] private GameObject prefab;

    public int obstacleDes;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DDPlayer"))
        {
            Destroy(prefab);
            DDWorldManager.Instance.IncreaseObstDes();
        }
    }
}
