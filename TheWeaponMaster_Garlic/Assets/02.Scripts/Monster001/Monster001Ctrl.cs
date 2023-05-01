using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Monster001Ctrl : MonoBehaviour
{
    public int monsterType = 1;
    public Rigidbody rb;
    public RaycastHit hit;
    public LayerMask ground;
    public float maxDistance = 2.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down, maxDistance, ground))
        {
            rb.useGravity = false;
            float vY = rb.velocity.y;
            vY = 0.0f;
        }
        Debug.DrawRay(transform.position, Vector3.down, Color.cyan, maxDistance);
    }
}
