using System;
using System.Collections.Generic;
using UnityEngine;

public class Swing : MonoBehaviour
{
    private float angularSpeed;
    private float bombHitSpeedIncrement = 2f;
    private float angularAccelerationFactor = 4f;
    private float dampFactor = 0.12f;
    [SerializeField] private List<HitDetector> hitDetectors;
    
    void Start()
    {
        foreach (HitDetector hd in hitDetectors)
        {
            hd.OnHit += ShipHitted;
        }
    }

    private void ShipHitted(HitDetector detector, Collision c)
    {
        Debug.Log("[Swing] ShipHitted " + detector.Label);
        // Obtenemos el punto de colisión de la bomba, en coordenadas globales
        Vector3 hitPoint = c.contacts[0].point;
        // Lo pasamos a coordenadas locales
        hitPoint = transform.InverseTransformPoint(hitPoint);
        // La coordenada X me dice si el golpe es por la derecha o por la izquierda
        if (hitPoint.x < 0)
        {
            Debug.Log("[Swing] ShipHitted Bombazo a babor");
            angularSpeed -= bombHitSpeedIncrement;
        }
        else
        {
            Debug.Log("[Swing] ShipHitted Bombazo a estribor");
            angularSpeed += bombHitSpeedIncrement;
        }
    }

    void Update()
    {
        float angularAcceleration = - angularAccelerationFactor * Angle180(transform.localEulerAngles.z);
        //Aplicamos la aceleración de restauración hacia la posición vertical
        // Esta es la que provoca que haya un movimiento de vaivén
        angularSpeed += angularAcceleration * Time.deltaTime;

        // Aplicamos el factor de amortiguación
        // Este es el que hace que la oscilación se vaya haciendo más pequeña cada vez
        angularSpeed -= dampFactor * angularSpeed * Time.deltaTime;

        // Esta línea provocaría una rotación loca por usar el eje Z del barco en coordenadas del mundo pero
        // aplicando el giro en referencia al sistema de coordenadas local
        //! transform.Rotate(transform.forward, angularSpeed * Time.deltaTime);

        // Estas son las líneas que funcionan
        //* transform.Rotate(new Vector3(0,0,1), angularSpeed * Time.deltaTime);
        //* transform.Rotate(Vector3.forward, angularSpeed * Time.deltaTime);
        transform.Rotate(transform.forward, angularSpeed * Time.deltaTime, Space.World);
    }

    private float Angle180(float angle)
    {
        if (angle <= 180)
        {
            return angle;
        }
        return angle - 360f;
    }

    
}
