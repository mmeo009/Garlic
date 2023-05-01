using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterHp : MonoBehaviour
{
    public float monsterHp;
    public int monsterType;
    GameObject monster;
    void Start()
    {
        monster = this.gameObject;
        monsterType = monster.GetComponent<Monster001Ctrl>().monsterType;

        if(monsterType == 1 )
        {
            monsterHp = 30;
        }
    }

    public void GetDmg(int dmg)
    {
        monsterHp -= dmg;
        if (monsterHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }

}
