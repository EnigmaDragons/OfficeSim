using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    private Vector3 followDistance;

    void Awake()
    {
        followDistance = transform.position - target.position;
    }

    private void LateUpdate()
    {
        var targetPos = target.position + followDistance;
        transform.position = Vector3.Lerp(transform.position, targetPos, 0.05f);
    }
}
