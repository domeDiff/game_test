using UnityEngine;

public class MDCamFollow : MonoBehaviour
{
private Transform player;
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
            newPositon.z = camera.transform.position.z;

            camera.transform.position = newPositon;
        }
        
    }
}
