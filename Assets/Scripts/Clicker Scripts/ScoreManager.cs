using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    public static Text scoreDisplay;
    public float timer;

    private void Start()
    {
        scoreDisplay = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        InvokeRepeating("Timer", 1, 0.25f);
    }
    public static void Increase()
    {
        if (!Health.monsterIsRespawning)
        {
            scoreDisplay.text = "Money: " + score;
        }
    }
    private void Timer()
    {
        score += ClickButton.amountPerSecond;
        Increase();
    }
}
