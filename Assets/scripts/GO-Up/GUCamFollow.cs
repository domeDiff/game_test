using UnityEngine;

public class GUCamFollow : MonoBehaviour
{
    [SerializeField] private float offsetValue = 4f;
    private Transform player;
    private new Camera camera;

    private void Awake()
    {
        camera = GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("GUPlayer").transform;
    }

    private void LateUpdate()
    {
        Vector3 offset = new Vector3(0f, offsetValue , 0f);
        if (player != null)
        {
            Vector3 newPosition = player.position;
            newPosition.z = camera.transform.position.z;
            newPosition.x = camera.transform.position.x; // Keep the camera's y position
            camera.transform.position = newPosition + offset;
        }
    }
}
