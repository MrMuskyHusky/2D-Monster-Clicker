﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public static float health;
    public static float maxHealth;
    private float _percentHealth;
    public static bool monsterIsRespawning;
    public bool isBoss;
    public Slider healthBar;
    public BackgroundSwitch backgroundSwitch;
    public static float respawnDelay;
    public Text healthText;
    public int roundedHealth;
    public int bossCounter = 10;
    private int backgroundCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        health = 10;
        maxHealth = health;
        monsterIsRespawning = false;
        respawnDelay = 0.5f;
        InvokeRepeating("Timer", 1, 0.25f);
        healthText = GameObject.FindGameObjectWithTag("Health").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && !monsterIsRespawning)
        {
            health = 0;
            monsterIsRespawning = true;
            MonsterKilled();
        }
    }
    private void LateUpdate()
    {
        if (healthBar.value != Mathf.Clamp01(health / maxHealth))
        {
            healthBar.value = Mathf.Clamp01(health / maxHealth);
            roundedHealth = (int)Mathf.Round(health);
            healthText.text = "HP: " + roundedHealth;
        }
    }

    void MonsterKilled()
    {
        // call growth script
        if (isBoss)
        {
            BossKill();
        }

        if (bossCounter > 0)
        {
            bossCounter--;
            Growth.HealthGrowth();
        }
        else
        {
            Growth.Boss();
            isBoss = true;
            bossCounter = 10;
        }

        
        // call respawn script to set helath back to full
        Invoke("Respawn", respawnDelay);
    }

    void Respawn()
    {
        health = maxHealth;
        monsterIsRespawning = false;
    }

    void Timer()
    {
        health -= ClickButton.amountPerSecond;
        // update slider value
    }

    void BossKill()
    {

        isBoss = false;
        Growth.BossDeath();
        backgroundCounter++;
        backgroundSwitch.SelectBackground(backgroundCounter);

    }
}
