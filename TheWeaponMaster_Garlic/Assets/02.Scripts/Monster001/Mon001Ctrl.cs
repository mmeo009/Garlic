using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Mon001Ctrl : MonsterController
{
    public float maxRange = 10.0f;
    public int weponType = 0;
    Rigidbody rb;
    public Ray ray;

    private void Start()
    {
        StatSetting(40, 1, 5.0f, 7.0f, 5.0f, 1);
        Debug.Log(Stats.HP);
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        ray = new Ray();
        ray.origin = transform.position;
        ray.direction = transform.TransformDirection(Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray.origin, ray.direction, out hit, maxRange))
        {
            if (hit.collider.tag == "Ground")
            {
                rb.AddForce(Vector3.up * 30.0f, ForceMode.Acceleration);
            }

            Debug.Log(hit.collider.name);
        }
    }
}
