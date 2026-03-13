using UnityEngine;

public class Buoyancy : MonoBehaviour
{
    private float verticalSpeed;
    private float verticalAccelerationFactor = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        float acceleration = - verticalAccelerationFactor * transform.position.y;
        verticalSpeed += acceleration * Time.deltaTime;
        transform.position += Vector3.up * verticalSpeed * Time.deltaTime;
    }
}
