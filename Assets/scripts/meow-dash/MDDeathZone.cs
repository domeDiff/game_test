using UnityEngine;

public class MDDeathZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out MDMovement player))
        {
            player.ChangeProp();
        }
    }
}
