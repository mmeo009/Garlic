using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Mon004Ctrl : MonsterController
{
    public GameObject me;
    public Transform player;
    public Rigidbody rb;
    public Vector3 targetPosition;
    public GameObject boom;
    void Start()
    {
        StatSetting(3, 30.0f, 1.0f, 1.0f, 4);
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

            if (Vector3.Distance(player.position, transform.position) > 1)
            //Vecter3.Distance (거리를 알려주는 함수)
            {
                Vector3 direction = (player.position - transform.position).normalized;
                rb.MovePosition(transform.position + direction * Stats.MoveSpeed * Time.deltaTime);
            }
            if (Vector3.Distance(player.position, transform.position) <= 1.5)
            {
                Boom();
            }


            targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
            me.transform.LookAt(targetPosition);
        }
    }

    void Boom()
    {
        GameObject temp = (GameObject)Instantiate(boom);
        temp.transform.position = this.gameObject.transform.position;
        Destroy(this.gameObject);
    }
}
