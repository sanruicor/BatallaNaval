using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<HitDetector> hitDetectors;
    private int maxHealth = 100;
    private int health = 100;
    private int hitDamage = 10;
    
    void Start()
    {
        foreach (HitDetector hd in hitDetectors)
        {
            hd.OnHit += ShipHitted;
        }
    }

    private void ShipHitted(HitDetector detector, Collision c)
    {
        health -= hitDamage;
        Debug.Log("[GameManager] " + health);

        UIController.instance.SetHealthBarValue(health, maxHealth);
    }

    void Update()
    {
        
    }
}
