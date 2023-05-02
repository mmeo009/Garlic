using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCtrl : MonoBehaviour
{
    public GameObject Monster;
    public GameObject hand;
    public float maxRange;
    public int weponType = 0;
    public Ray ray;
    private void Start()
    {
    }
    private void OnDrawGizmos()
    {

        Debug.DrawLine(ray.origin, ray.direction * maxRange, Color.red);
        //화면에 레이를 보여줌
    }
    void Update()
    {
        if(weponType == 0)
        {
            maxRange = 30.0f;
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            ray = new Ray();
            ray.origin = hand.transform.position;
            ray.direction = hand.transform.TransformDirection(Vector3.forward);

            if (Physics.Raycast(ray.origin,ray.direction,out hit,maxRange))
            //Rast가 충돌된것을 hit로 돌려준다.
            {
                if (hit.collider.tag == "Monster")
                {
                    hit.collider.gameObject.GetComponent<MonsterHp>().GetDmg(1);
                }
                Debug.Log(hit.collider.name);
                //오브젝트 이름 출력
            }
        }
    }
}
