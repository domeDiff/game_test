using UnityEngine;

public class MDCamFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    private new Camera camera;

    private void Awake()
    {
        camera = GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("MDPlayer").transform;
    }

    private void LateUpdate()
    {
        if(player != null)
        {
            Vector3 newPositon = player.position;

            camera.transform.position = newPositon;
        }
        
    }
}
