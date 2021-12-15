using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Player Player;
    public Vector3 PlatformToCameraOffset;
    public float Speed;

    void Update()
    {
        if (Player.CurrentPlatform == null) return;

        Vector3 lowerPoint = new Vector3(Player.CurrentPlatform.transform.position.x, Mathf.Min(Player.CurrentPlatform.transform.position.y), Player.CurrentPlatform.transform.position.z);
            Vector3 targetPosition = lowerPoint + PlatformToCameraOffset;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Speed * Time.deltaTime);
        
    }
}
