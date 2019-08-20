using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemySwitcher : MonoBehaviour
{
    public Button click;
    public Image image;
    public Sprite[] monsters = new Sprite[4];
    
    public bool spawnEnemy = false;
    private int compare = 0;

    // Start is called before the first frame update
    void Start()
    {
        click = GameObject.FindGameObjectWithTag("Click").GetComponent<Button>();
        image = click.GetComponent<Image>();
        monsters[0] = Resources.Load<Sprite>("monster1");
        monsters[1] = Resources.Load<Sprite>("monster2");
        monsters[2] = Resources.Load<Sprite>("monster3");
        monsters[3] = Resources.Load<Sprite>("monster4");
        image.sprite = monsters[0];

    }

    // Update is called once per frame
    void Update()
    {
        if (Health.monsterIsRespawning && !spawnEnemy)
        {
            Invoke("ChangeSprite", 0.5f);
        }

        if (!Health.monsterIsRespawning && spawnEnemy)
        {
            spawnEnemy = false;
        }

    }

    public void ChangeSprite()
    {
        int random = Random.Range(0, 3);

        while (random == compare)
        {
            random = Random.Range(0, 3);
        }

        compare = random;
        image.sprite = monsters[random];
        spawnEnemy = true;
    }

    
}
