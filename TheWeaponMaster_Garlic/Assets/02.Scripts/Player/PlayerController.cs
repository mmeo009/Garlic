using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlayerController : GeneralAnimation
{

    float h, v;
    Vector3 moveDir;
    float dashTime = 30.0f;
    float nowSpeed;
    private void Start()
    {
        StatSetting(5, 5, 5.0f, 10.0f, 5.0f, 0);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        nowSpeed = Stats.MoveSpeed;
    }
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        moveDir = (Vector3.forward * v) + (Vector3.right * h);

        if(Input.GetKey(KeyCode.LeftShift)) 
        {
            if(dashTime > 0) 
            {
                nowSpeed = Stats.DashSpeed;
                dashTime -= Time.deltaTime;
            }
        }
        if (dashTime < 30.0f)
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                nowSpeed = Stats.MoveSpeed;
                dashTime += Time.deltaTime;
            }
        }
        transform.Translate(moveDir.normalized * Stats.MoveSpeed * Time.deltaTime, Space.Self);
    }
}
