using UnityEngine;
using UnityEngine.InputSystem;

public class CannonPivot : MonoBehaviour
{
    [SerializeField] private CannonShot leftCannon;
    [SerializeField] private CannonShot rightCannon;
    private float slowAngularSpeed = 8f;
    private float fastAngularSpeed = 40f;
    private float actualAngularSpeed = 0f;

    //private float fireRate = 4f;
    //private float nextFireTime;


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

        if (Keyboard.current.upArrowKey.isPressed)
        {
            actualAngularSpeed *= -1f;
        }
        else if (!Keyboard.current.downArrowKey.isPressed)
        {
            actualAngularSpeed = 0;
        }

        Vector3 newEulerAngles = transform.localEulerAngles;
        newEulerAngles += Vector3.right * actualAngularSpeed * Time.deltaTime;
        if (newEulerAngles.x > 5)
        {
            newEulerAngles.x = Mathf.Clamp(newEulerAngles.x, 285f, 359.9f);
        }
        else
        {
            newEulerAngles.x = 359.9f;
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            leftCannon.Shot();
            rightCannon.Shot();
        }

        // //Hacemos que el cañon dispare como máximo cada 4 segundos
        //         if (Keyboard.current.spaceKey.wasPressedThisFrame && Time.time >= nextFireTime)
        //         {
        //             leftCannon.Shot();
        //             rightCannon.Shot();
        //             nextFireTime = Time.time + fireRate;
        //         }
       

        transform.localEulerAngles = newEulerAngles;
    }
}
