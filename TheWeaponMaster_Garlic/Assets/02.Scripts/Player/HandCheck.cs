using UnityEngine;

public class HandCheck : MonoBehaviour
{
    public GameObject player;
    public int dmg;
    private void Update()
    {
        dmg = player.GetComponent<AttackCtrl>().dmg;
    }
    void OnTriggerEnter(Collider other)
    {
        if (player.GetComponent<AttackCtrl>().isAttack == true)
        {
            if (other.gameObject.tag == "Monster")
            {
                other.gameObject.GetComponent<MonsterController>().GetDmg(dmg);
            }
        }
    }
}
