using UnityEngine;

public class HandCheck : MonoBehaviour
{
    public GameObject player;
    void OnTriggerEnter(Collider other)
    {
        if (player.GetComponent<AttackCtrl>().isAttack == true)
        {
            if (other.gameObject.tag == "Monster")
            {
                other.gameObject.GetComponent<MonsterController>().GetDmg(2);
            }
        }
    }
}
