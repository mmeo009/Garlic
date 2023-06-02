using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CreatureStats : MonoBehaviour
{

    protected BaisicStats Stats;

    protected virtual void StatSetting(int hp, float moveSpeed, float stat2, float stat3, int creatureType)
    {
        Stats.HP = hp;
        Stats.MoveSpeed = moveSpeed;
        Stats.Stat2 = stat2;
        Stats.Stat3 = stat3;
        Stats.CreatureType = creatureType;
    }
    protected struct BaisicStats
    {
        public int HP;
        public float MoveSpeed;
        public float Stat2;
        public float Stat3;
        public int CreatureType;
    }
}
