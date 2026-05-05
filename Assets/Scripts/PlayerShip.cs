using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShip : MonoBehaviour {
    private float powerLevel = 0f;
    private float rudderLevel = 0f;
    private float baseSpeed = 0.8f;
    private float baseAngularSpeed = 1.2f;
    private float actualSpeed = 0f;
    private float actualAngularSpeed = 0f;
    private float rudderSpeedCorrectionBase = 0.2f;

    void Start()
    {
        
    }

    void Update() {
        if(Keyboard.current.wKey.wasPressedThisFrame) {
            powerLevel += 1f;
        }
        if(Keyboard.current.sKey.wasPressedThisFrame)  {
            powerLevel -= 1f;
        }
        powerLevel = Mathf.Clamp(powerLevel, -2f, 6f);

        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            rudderLevel -= 1f;
        }
        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            rudderLevel += 1f;
        }
        rudderLevel = Mathf.Clamp(rudderLevel, -3f, 3f);

        actualSpeed = baseSpeed * powerLevel;
        actualAngularSpeed = baseAngularSpeed * rudderLevel;
        if (actualSpeed == 0)
        {
           actualAngularSpeed = 0;
        }
        else
        {
            // Hay que corregir la velocidad de avance del barco disminuyéndola en función del rudderLevel aplicado
            // esta corrección solo se puede hacer si hay velocidad de movimiento lineal
            actualSpeed -= rudderSpeedCorrectionBase * Mathf.Abs(rudderLevel);
        }

        transform.position += transform.forward * actualSpeed * Time.deltaTime;
        // Tenemos que usar el signo de powerLevel para que el giro se aplique al revés cuando el barco retrocede
        transform.eulerAngles += Vector3.up * actualAngularSpeed * Time.deltaTime * Mathf.Sign(powerLevel);

        UIController.instance.SetPowerValue(powerLevel);
        UIController.instance.SetSpeedValue(actualSpeed);
        UIController.instance.SetRudderValue(rudderLevel);
    }


    // void OnGUI() {
    //     int screenH = Screen.height;
    //     int labelWidth = 150;
    //     int labelHeight = 20;

    //     GUI.Label(new Rect(10, screenH - 80,labelWidth, labelHeight),"Speed: " + actualSpeed);
    //     GUI.Label(new Rect(10, screenH - 60,labelWidth, labelHeight),"PowerLevel: " + powerLevel);
    //     GUI.Label(new Rect(10, screenH - 40,labelWidth, labelHeight),"AngularSpeed: " + actualAngularSpeed);
    //     GUI.Label(new Rect(10, screenH - 20,labelWidth, labelHeight),"RudderLevel: " + rudderLevel);
    // }

}
