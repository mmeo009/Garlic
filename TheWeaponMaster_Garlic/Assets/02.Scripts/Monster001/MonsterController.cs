using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class MonsterController : GeneralAnimation
{
    private void Start()
    {
        int type = Stats.CreatureType;
    }
    
    public void GetDmg(int dmg)
    {
        Stats.HP -= dmg;
        if (Stats.HP <= 0)
        {
            Destroy(this.gameObject);
        }
        Debug.Log(Stats.HP);
    }
    public void AttackCoolDown()
    {

    }

}


