using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBar : PlayerController
{
    public float maxHpVal;
    public float maxSteVal = 20.0f;
    public float nowHpVal;
    public float nowSteVal;
    public Image hpImage;
    public Image steImage;
    public GameObject creature;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        maxHpVal = maxHp;
        nowHpVal = Stats.HP;
        nowSteVal = dashTime;
        if (creature != null)
        {
            hpImage.fillAmount = nowHpVal / maxHpVal;
            steImage.fillAmount = nowSteVal / maxSteVal;
        }
    }
}
