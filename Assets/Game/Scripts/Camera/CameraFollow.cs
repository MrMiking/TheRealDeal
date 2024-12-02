using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private Transform _target;
    [SerializeField] private float smoothSpeed;
    [SerializeField] private Vector3 _positionOffset;

    private void Update()
    {
        Vector3 desiredPosition = _target.position + _target.rotation * _positionOffset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
