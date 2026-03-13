using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform cameraMountPoint;
    void Start()
    {
        
    }

    void LateUpdate()
    {
        transform.position = cameraMountPoint.position;
        transform.rotation = cameraMountPoint.rotation;
    }
}
