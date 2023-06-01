using UnityEngine;
using UnityEngine.UI;

public class ScrollBar : MonoBehaviour
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
        maxSteVal = 20.0f;
    }
    void Update()
    {
        maxHpVal = creature.GetComponent<PlayerController>().maxHp;
        nowHpVal = creature.GetComponent<PlayerController>().nowHp;
        nowSteVal = creature.GetComponent<PlayerController>().dashTime;
    }
    void FixedUpdate()
    {
        if (creature != null)
        {
            hpImage.fillAmount = nowHpVal / maxHpVal;
            steImage.fillAmount = nowSteVal / maxSteVal;
        }
    }
}
