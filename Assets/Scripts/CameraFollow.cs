using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed = 0.1f;
    [SerializeField] private Vector2 offset;
    [SerializeField] private float minY;
    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        if (target == null) return;

        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, Mathf.Max(target.position.y + offset.y, minY), transform.position.z);
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
    }
}
