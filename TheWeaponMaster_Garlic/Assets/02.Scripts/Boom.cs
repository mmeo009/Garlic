using UnityEngine;

public class Boom : MonoBehaviour
{
    public Collider[] colls;
    public float time = 0.5f;
    void Update()
    {
        // �ݰ� 10f�� ��ġ�� ������Ʈ���� �迭�� ��´�
        colls = Physics.OverlapSphere(transform.position, 10f);
        // foreach���� ���ؼ� colls�迭�� �����ϴ� ������ ����ȿ���� �������ش�.
        foreach (Collider coll in colls)
        {
            // �ش� ������Ʈ�� Rigidbody�� �����ͼ� AddExplosionForce �Լ��� ������ش�.
            // AddExplosionForce(���߷�, ������ġ, �ݰ�, ���� �ڱ��Ŀø��� ��)
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


