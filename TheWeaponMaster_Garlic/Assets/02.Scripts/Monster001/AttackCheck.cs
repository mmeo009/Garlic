using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCheck : MonoBehaviour
{
    public GameObject me;

    void OnTriggerEnter(Collider other)
    {
        if (me == null)
        {
            if (other.gameObject.tag == "Monster")
            {
                me = other.gameObject;
            }
        }
        else
        {
            if (me.GetComponent<Mon001Ctrl>().areHandsMoves == true)
            {
                if(other.gameObject.tag == "Player")
                {
                    other.gameObject.GetComponent<PlayerController>().GetDMG(1);
                }
            }
        }
    }
}
