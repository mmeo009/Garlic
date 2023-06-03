using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End : MonoBehaviour
{
    public int whoAmI;
    public float spin;
    public Transform Target;
    private void Awake()
    {
        switch (this.gameObject.tag)
        {
            case "0" :
                whoAmI = 0;
                break;
            case "1":
                whoAmI = 1;
                break;
        }
        spin = Random.Range(70.0f, 150.0f);
    }
    private void Update()
    {
        if (whoAmI == 0)
        {
            transform.Rotate(new Vector3(0, spin, 0) * Time.deltaTime); ;
        }
        else
        {
            transform.RotateAround(Target.position, Vector3.up, -60 * Time.deltaTime);
        }
    }
}
