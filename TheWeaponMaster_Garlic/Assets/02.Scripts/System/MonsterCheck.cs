using UnityEngine;

public class MonsterCheck : MonoBehaviour
{
    public int difficulty;
    public int maxAmount;
    public int amount;
    public int kill;
    public float birdSpawnTime;
    private Object[] monster;
    public GameObject monster1, monster2, monster3, monster4;
    private int lv;
    void Start()
    {
        switch (this.gameObject.tag)
        {
            case "Lv_1":
                lv = 0;
                break;
            case "Lv_2":
                lv = 1;
                break;
            case "Lv_3":
                lv = 2;
                break;
        }
        Difficulty(lv);
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
    private void Update()
    {
        birdSpawnTime -= Time.deltaTime;
        if (birdSpawnTime < 0)
        {
            BirdSpawn();
            birdSpawnTime = 10.0f;
        }
    }
    void Difficulty(int lv)
    {
        difficulty = lv;
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
    void BirdSpawn()
    {

    }
    void GarlicSpawn()
    {

    }
}
