using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mon002Ctrl : MonsterController
{
    public GameObject me;
    public Transform player;
    public Rigidbody rb;
    void Start()
    {
        StatSetting(3, 5, 10.0f, 10.0f, 5.0f, 2);
        rb = GetComponent<Rigidbody>();
        me = this.gameObject;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 targetDiraction = (player.position - me.transform.position).normalized;

                Quaternion targetRotation = Quaternion.LookRotation(targetDiraction);

                if (Vector3.Distance(player.position, transform.position) > 7)
                //Vecter3.Distance (거리를 알려주는 함수)
                {
                    Vector3 direction = (player.position - transform.position).normalized;
                    rb.MovePosition(transform.position + direction * Stats.MoveSpeed * Time.deltaTime);
                }
                me.transform.rotation = Quaternion.Lerp(me.transform.rotation, targetRotation, Stats.DashSpeed * Time.deltaTime);
        }
    }
}
