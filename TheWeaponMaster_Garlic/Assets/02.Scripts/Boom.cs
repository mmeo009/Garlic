using UnityEngine;

public class Boom : MonoBehaviour
{
    public Collider[] colls;
    public float time = 0.5f;
    void Update()
    {
        // 반경 10f에 위치한 오브젝트들을 배열에 담는다
        colls = Physics.OverlapSphere(transform.position, 10f);
        // foreach문을 통해서 colls배열에 존재하는 각각에 폭발효과를 적용해준다.
        foreach (Collider coll in colls)
        {
            // 해당 오브젝트의 Rigidbody를 가져와서 AddExplosionForce 함수를 사용해준다.
            // AddExplosionForce(폭발력, 폭발위치, 반경, 위로 솟구쳐올리는 힘)
            if (coll.gameObject.tag == "Player")
            {
                coll.GetComponent<Rigidbody>().AddExplosionForce(4.0f, transform.position, 3.0f, 0.0f);               
            }
        }

    }
    private void FixedUpdate()
    {
        time -= Time.deltaTime;

        if(time <= 0)
            Destroy(this.gameObject);
    }
}


