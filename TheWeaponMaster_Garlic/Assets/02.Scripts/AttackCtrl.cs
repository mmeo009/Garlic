using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCtrl : MonoBehaviour
{
    public GameObject Monster;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray cast = Camera.main.ScreenPointToRay(Input.mousePosition);
            //ȭ�鿡���� 2���� ���콺 

            RaycastHit hit;

            if (Physics.Raycast(cast, out hit))
            //Rast�� �浹�Ȱ��� hit�� �����ش�.
            {
                if (hit.collider.tag == "Monster")
                {
                    hit.collider.gameObject.GetComponent<MonsterHp>().GetDmg(1);
                }

                Debug.Log(hit.collider.name);
                //������Ʈ �̸� ���

                Debug.DrawLine(cast.origin, hit.point, Color.red, 2.0f);
                //ȭ�鿡 ���̸� ������
            }
        }
    }
}
