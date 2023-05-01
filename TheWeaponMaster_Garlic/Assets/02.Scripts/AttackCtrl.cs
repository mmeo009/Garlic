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
            //화면에서의 2차원 마우스 

            RaycastHit hit;

            if (Physics.Raycast(cast, out hit))
            //Rast가 충돌된것을 hit로 돌려준다.
            {
                if (hit.collider.tag == "Monster")
                {
                    hit.collider.gameObject.GetComponent<MonsterHp>().GetDmg(1);
                }

                Debug.Log(hit.collider.name);
                //오브젝트 이름 출력

                Debug.DrawLine(cast.origin, hit.point, Color.red, 2.0f);
                //화면에 레이를 보여줌
            }
        }
    }
}
