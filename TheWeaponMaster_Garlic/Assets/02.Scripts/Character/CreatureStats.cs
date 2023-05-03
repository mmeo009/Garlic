using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureStats : MonoBehaviour
{

    protected BaisicStats Stats;

    protected virtual void StatSetting(int hp, int atk, float moveSpeed, float dashSpeed, float jumpForce, int creatureType)
    {
        Stats.HP = hp;
        Stats.ATK = atk;
        Stats.MoveSpeed = moveSpeed;
        Stats.DashSpeed = dashSpeed;
        Stats.JumpForce = jumpForce;
        Stats.CreatureType = creatureType;
    }
    protected struct BaisicStats
    {
        public int HP;
        public int ATK;
        public float MoveSpeed;
        public float DashSpeed;
        public float JumpForce;
        public int CreatureType;
    }
}
