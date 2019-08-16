using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemySwitcher : MonoBehaviour
{
    public Button click;
    public Image image;
    public Sprite[] monsters = new Sprite[4];
    string m_Path;
    public bool SpawnEnemy = false;
    int compare = 0;

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

        //Get the path of the Game data folder
        m_Path = Application.dataPath;

        //Output the Game data path to the console
        Debug.Log("Path : " + m_Path);

    }

    // Update is called once per frame
    void Update()
    {
        if (Health.monsterIsRespawning && !SpawnEnemy)
        {  
            int random = Random.Range(0, 3);
            while (random == compare)
            {
                random = Random.Range(0, 3);
                Debug.Log("UNLUCKY");
            }
            compare = random;
            image.sprite = monsters[random];
            Debug.Log("New Enenmy");
            SpawnEnemy = true;
            Invoke("Swap", Health.respawnDelay);
        }

    }
    void Swap()
    {
        if (SpawnEnemy)
        {
            SpawnEnemy = false;
        }
        else
        {
            Debug.Log("DONT CALL THBIKS MORE YTHAN ONCE");
        }
    }
}
