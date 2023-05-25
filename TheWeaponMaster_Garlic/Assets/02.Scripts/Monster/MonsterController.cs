using UnityEditor;
using UnityEngine;

public class MonsterController : CreatureStats
{
    public GameObject item001, item002, item003;
    private void Awake()
    {
        int type = Stats.CreatureType;
        Debug.Log(type);
        item001 = Resources.Load("HP") as GameObject;
        item002 = Resources.Load("DMG") as GameObject;
        item003 = Resources.Load("SPEED") as GameObject;
    }

    public void GetDmg(int dmg)
    {
        Stats.HP -= dmg;
        if (Stats.HP <= 0)
        {
            Destroy(this.gameObject);

            switch (Stats.CreatureType)
            {
                case 2:
                    GameObject item1 = (GameObject)Instantiate(item001);
                    item1.transform.position = this.gameObject.transform.position + new Vector3(0,-1,0);
                    break;
                case 3:
                    GameObject item2 = (GameObject)Instantiate(item002);
                    item2.transform.position = this.gameObject.transform.position + new Vector3(0, -1, 0);
                    break;
                case 4:
                    GameObject item3 = (GameObject)Instantiate(item003);
                    item3.transform.position = this.gameObject.transform.position + new Vector3(0, -1, 0);
                    break;
            }
        }
        Debug.Log(Stats.HP);
    }
}


