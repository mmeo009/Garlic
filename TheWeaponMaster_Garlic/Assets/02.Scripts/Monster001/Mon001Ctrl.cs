using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mon001Ctrl : MonsterController
{
    public float maxRange;
    public int weponType = 0;
    public Ray ray;
    private void Start()
    {
        StatSetting(40, 1, 5.0f, 7.0f, 5.0f, 1);
        Debug.Log(Stats.HP);
    }

    private void LateUpdate()
    {
        RaycastHit hit;
        ray = new Ray();
        ray.origin = transform.position;
        ray.direction = transform.TransformDirection(Vector3.down);

        if (Physics.Raycast(ray.origin, ray.direction, out hit, maxRange))
        //Rast�� �浹�Ȱ��� hit�� �����ش�.
        {
            if (hit.collider.tag == "Ground")
            {
            }
            Debug.Log(hit.collider.name);
            //������Ʈ �̸� ���
        }
    }
}
