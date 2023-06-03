using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterCheck : MonoBehaviour
{
    public int difficulty;
    public int maxAmount;
    public int amount;
    public int kill;
    public float birdSpawnTime;
    private Object[] monster;
    public GameObject monster1, monster2, monster3, monster4;
    void Awake()
    {
        monster = Resources.LoadAll("monster");
        for (int i = 0; i < monster.Length; i++)
        {
            switch (i)
            {
                case 0:
                    monster1 = monster[i] as GameObject;
                    break;
                case 1:
                    monster2 = monster[i] as GameObject;
                    break;
                case 2:
                    monster3 = monster[i] as GameObject;
                    break;
                case 3:
                    monster4 = monster[i] as GameObject;
                    break;
            }
        }
    }
    void Start()
    {
        switch (this.gameObject.tag)
        {
            case "Lv_1":
                difficulty = 0;
                break;
            case "Lv_2":
                difficulty = 1;
                break;
            case "Lv_3":
                difficulty = 2;
                break;
        }
        Difficulty(difficulty);
        GarlicSpawn(maxAmount);
    }
    private void Update()
    {
        birdSpawnTime -= Time.deltaTime;
        if (birdSpawnTime < 0)
        {
            BirdSpawn(difficulty + 2);
            birdSpawnTime = 10.0f;
        }
    }
    public void AmountChack()
    {
        if(amount < maxAmount)
        {
            amount--;
        }
        if(amount <= maxAmount)
        {
            End();
        }
    }
    void Difficulty(int lv)
    {
        switch (difficulty)
        {
            case 0:
                maxAmount = 7;
                birdSpawnTime = 10.0f;
                break;
            case 1:
                maxAmount = 14;
                birdSpawnTime = 7.0f;
                break;
            case 2:
                maxAmount = 20;
                birdSpawnTime = 5.0f;
                break;
        }
    }
    void BirdSpawn(int birds)
    {
        while (birds > 0)
        {
            int spawnX = Random.Range(-250, 250);
            int spawnY = Random.Range(-250, 250);
            int whichBird = Random.Range(0, 2);
            switch (whichBird)
            {
                case 0:
                    GameObject B1 = (GameObject)Instantiate(monster2);
                    B1.transform.position = new Vector3(spawnX, 1, spawnY);
                    break;
                case 1:
                    GameObject B2 = (GameObject)Instantiate(monster3);
                    B2.transform.position = new Vector3(spawnX, 1, spawnY);
                    break;
                case 2:
                    GameObject B3 = (GameObject)Instantiate(monster4);
                    B3.transform.position = new Vector3(spawnX, 1, spawnY);
                    break;
            }
            birds--;
        }
    }
    void GarlicSpawn(int howMany)
    {
        for (int i = 0; i < 10; i++)
        {
            int spawnX = Random.Range(-250, 250);
            int spawnY = Random.Range(-250, 250);

            GameObject temp = (GameObject)Instantiate(monster1);
            temp.transform.position = new Vector3(spawnX, 1, spawnY);
        }
    }
    public void End()
    {
        SceneManager.LoadScene("End");
    }
}
