using UnityEngine;

public class FCCamFollow : MonoBehaviour
{
    private new Camera camera;
    private Transform player;

    private void Start()
    {
        camera = GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("FCPlayer").transform;
    }

    private void LateUpdate()
    {
        if (player != null)
        {
            Vector3 newPosition = player.position;
            newPosition.z = camera.transform.position.z;
            newPosition.y = camera.transform.position.y; // Keep the camera's y position
            camera.transform.position = newPosition;
        }
    }


}
