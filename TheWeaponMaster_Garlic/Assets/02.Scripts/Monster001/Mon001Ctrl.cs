using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Mon001Ctrl : MonsterController
{
    private void Start()
    {
        StatSetting(40, 1, 5.0f, 7.0f, 5.0f, 1);
        Debug.Log(Stats.HP);
    }
}
