using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    [SerializeField] private TextMeshProUGUI powerValue;
    [SerializeField] private TextMeshProUGUI directionValue;
    [SerializeField] private TextMeshProUGUI speedValue;
    [SerializeField] private TextMeshProUGUI rudderValue;
    [SerializeField] private TextMeshProUGUI rudderDirectionValue;
    [SerializeField] private Image cannonLoadIndicator;
    [SerializeField] private Color loadedColor;
    [SerializeField] private Color unloadedColor;
    [SerializeField] private List<Image> healthBarLeds;
    [SerializeField] private Color healthBarLeftColor;
    [SerializeField] private Color healthBarRightColor;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        InitilizeHealthBar();
    }

    public void SetPowerValue(float value)
    {
        powerValue.text = Mathf.Abs(value).ToString("0");
        directionValue.text = "";
        if (value > 0f)
        {
            directionValue.text = "FWD";
        }
        else if (value < 0)
        {
            directionValue.text = "BWD";
        }
    }

    internal void SetSpeedValue(float value)
    {
        speedValue.text = value.ToString("0.00");
    }

    internal void SetRudderValue(float value)
    {
        rudderValue.text = Mathf.Abs(value).ToString();
        rudderDirectionValue.text = "";
        if (value > 0f)
        {
            rudderDirectionValue.text = "R";
        }
        else if (value < 0)
        {
            rudderDirectionValue.text = "L";
        }
    }

    public void SetCannonLoadStatus(bool loaded)
    {
        cannonLoadIndicator.color = loaded ? loadedColor : unloadedColor;
    }

    public void SetHealthBarValue(int currentHealthValue, int maxHealthValue)
    {
        int ledCount = healthBarLeds.Count;
        int activeLeds = (int) Mathf.Round((float) ledCount * currentHealthValue / maxHealthValue);

        for (int i = 0; i < ledCount; i++)
        {
            healthBarLeds[i].enabled = i < activeLeds;
        }
    }

    private void InitilizeHealthBar()
    {
        int ledCount = healthBarLeds.Count;

        for (int i = 0; i < ledCount; i++)
        {
            healthBarLeds[i].color = Color.Lerp(healthBarLeftColor, healthBarRightColor, (float) i/(ledCount-1));
        }
    }
}
