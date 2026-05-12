using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private List<HitDetector> playerHitDetectors;
    [SerializeField] private List<HitDetector> enemyHitDetectors;
    private int maxHealth = 100;
    private int health = 100;
    private int hitDamage = 10;
    private int score = 0;
    private int hitPoints = 20;
    private bool gameOver;
    public bool GameOver => gameOver;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        foreach (HitDetector hd in playerHitDetectors)
        {
            hd.OnHit += ShipHitted;
        }

        foreach (HitDetector hd in enemyHitDetectors)
        {
            hd.OnHit += EnemyHitted;
        }

        HighScoreUIController.instance.gameObject.SetActive(false);
    }

    private void ShipHitted(HitDetector detector, Collision c)
    {
        health -= hitDamage;
        Debug.Log("[GameManager] " + health);

        UIController.instance.SetHealthBarValue(health, maxHealth);

        if (health < 0)
        {
            SetGameOver();
        }
    }

    private void EnemyHitted(HitDetector detector, Collision c)
    {
        score += hitPoints;
        UIController.instance.SetScorePoints(score);
    }

    private void SetGameOver()
    {
        gameOver = true;
        HighScoreUIController.instance.gameObject.SetActive(true);
        HighScoreUIController.instance.SetScore(score);
    }
}
