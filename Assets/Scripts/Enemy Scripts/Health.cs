using System.Collections;
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
            monsterIsRespawning = true;
            MonsterKilled();
        }
    }
    private void LateUpdate()
    {
        if (health < 0)
        {
            health = 0;
        }

        if (healthBar.value != Mathf.Clamp01(health / maxHealth))
        {
            healthBar.value = Mathf.Clamp01(health / maxHealth);
            roundedHealth = (int)Mathf.Round(health);
            healthText.text = "HP: " + roundedHealth;
        }
    }

    void MonsterKilled()
    {
        // if the monster which died is also a boss run the script
        if (isBoss)
        {
            BossKill();
        }

        // if the monster which died is not the last monster before the boss, spawn a normal monster
        if (bossCounter > 0)
        {
            bossCounter--;
            Growth.HealthGrowth();
        }
        else // otherwise spawn the boss 
        {
            Growth.Boss();
            isBoss = true;
            bossCounter = 10;
        }

        
        // call respawn script after a certain delay to set health back to full
        Invoke("Respawn", respawnDelay);
    }

    void Respawn()
    {
        health = maxHealth; // Sets health to the max health of the enemy.
        monsterIsRespawning = false; // The monster has respawned so the enemy is no longer respwaning.
    }

    void Timer()
    {
        if(!monsterIsRespawning)
        {
            health -= ClickButton.amountPerSecond; // decreases the mosnter health if the mosnter is alive
        }

    }

    void BossKill() // called if the boss dies
    {
        
        isBoss = false;
        Growth.BossDeath(); // lowers health so all the monster arent bloody bosses
        backgroundCounter++; // switches background
        backgroundSwitch.SelectBackground(backgroundCounter);

    }
}
