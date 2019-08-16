using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickButton : MonoBehaviour
{

    public static int clickValue; // Damage per click
    public static int amountPerSecond; // Damager per second

    private void Start()
    {
        clickValue = 1; // Starting Click Damage
        amountPerSecond = 0; // Starting DPS
    }

    public void ClickerButton()
    {
        CriticalHit.CritCheck();
        ScoreManager.Increase(); // Update the health slider value.
    }
    
}