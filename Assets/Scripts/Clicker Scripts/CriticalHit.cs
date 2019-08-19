﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalHit : MonoBehaviour
{
    public static float critChance;
    public static float critDamage;

    // Start is called before the first frame update
    void Start()
    {
        critChance = 100.0f;
        critDamage = 2f;
    }

    public static void CritCheck()
    {
        float critRoll = Random.Range(0f, 100f);
        if (critRoll <= critChance)
        {
            // CRIT CONDITION
            Health.health -= ClickButton.clickValue * critDamage; // Health.
            ScoreManager.score += ClickButton.clickValue * critDamage; // Increase gold.
        }

        else
        {
            // NOT CRIT CONDITION
            Health.health -= ClickButton.clickValue;  // Health.
            ScoreManager.score += ClickButton.clickValue; // Increase gold.
        }

    }
}
