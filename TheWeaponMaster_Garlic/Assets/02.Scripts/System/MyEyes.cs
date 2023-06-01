using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyEyes : MonoBehaviour
{
    public GameObject floor;
    public Material material;
    private void Start()
    {
        floor = this.gameObject;
        material = floor.GetComponent<Material>();
    }
    private void Update()
    {
    }
}
