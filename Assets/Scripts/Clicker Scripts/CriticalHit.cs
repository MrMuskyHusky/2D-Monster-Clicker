using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriticalHit : MonoBehaviour
{
    public static float critChance;
    // Start is called before the first frame update
    void Start()
    {
        critChance = 50.0f;
    }

    public static void CritCheck()
    {
        float critRoll = Random.Range(0f, 100f);
        Debug.Log(critRoll);
        if (critRoll <= critChance)
        {
            // CRIT CONDITION
            Health.health -= ClickButton.clickValue * 2; // Health.
            ScoreManager.score += ClickButton.clickValue * 2; // Increase gold.
        }

        else
        {
            // NOT CRIT CONDITION
            Health.health -= ClickButton.clickValue;  // Health.
            ScoreManager.score += ClickButton.clickValue; // Increase gold.
        }

    }
}
