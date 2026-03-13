using UnityEngine;
using UnityEngine.InputSystem;

public class CabinPivot : MonoBehaviour
{

    private float slowAngularSpeed = 16f;
    private float fastAngularSpeed = 80f;
    private float actualAngularSpeed = 0f;

    void Start()
    {

    }

    void Update()
    {
        actualAngularSpeed = slowAngularSpeed;
        if (Keyboard.current.ctrlKey.isPressed)
        {
            actualAngularSpeed = fastAngularSpeed;
        }

        if(Keyboard.current.leftArrowKey.isPressed)
        {
            actualAngularSpeed *= -1f;
        }
        else if(!Keyboard.current.rightArrowKey.isPressed)
        {
            actualAngularSpeed = 0;
        }

        transform.localEulerAngles += Vector3.up * actualAngularSpeed * Time.deltaTime;
    }
}
