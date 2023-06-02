using DG.Tweening;
using UnityEngine;

public class Mon001Ctrl : MonsterController
{
    public float time = 4.0f;
    public bool areHandsMoves;

    public GameObject me;
    public GameObject hands;
    public GameObject system;
    public Transform player;
    public Rigidbody rb;

    public Sequence sequenceLoop;

    public Vector3 targetDiraction;


    void Start()
    {
        StatSetting(7, 20.0f, 10.0f, 0.0f, 1);
        Debug.Log(Stats.HP);
        rb = GetComponent<Rigidbody>();
        me = this.gameObject;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        system = GameObject.Find("System");
        sequenceLoop = DOTween.Sequence();
    }
    void Update()
    {

        if (player != null)
        {

            targetDiraction = (player.position - me.transform.position).normalized;

            Quaternion targetRotation = Quaternion.LookRotation(targetDiraction);

            if (areHandsMoves == false)
            {
                if (Vector3.Distance(player.position, transform.position) > 5)
                //Vecter3.Distance (거리를 알려주는 함수)
                {
                    Vector3 direction = (player.position - transform.position).normalized;
                    rb.MovePosition(transform.position + direction * Stats.MoveSpeed * Time.deltaTime);
                }

            }
            me.transform.rotation = Quaternion.Lerp(me.transform.rotation, targetRotation, Stats.Stat2 * Time.deltaTime);
        }
    }

    private void LateUpdate()
    {
        if (Vector3.Distance(player.position, transform.position) <= 5)
        {
            if (areHandsMoves == false)
            {

                areHandsMoves = true;
                StartAttack();
            }
        }
        if (Vector3.Distance(hands.transform.position, transform.position) >= 2)
        {
            if (areHandsMoves == false)
                HandQuickBack();
        }
    }
    void StartAttack()
    {
        Vector3 vel = Vector3.zero;
        hands.transform.DOJump(player.position, 5.0f, 1, 1.0f).OnComplete(HandBack);

    }
    void HandBack()
    {
        hands.transform.DOMove(me.transform.position, 3).OnComplete(EndAttack).SetDelay(0.3f);
    }
    void HandQuickBack()
    {
        hands.transform.DOMove(me.transform.position, 1).OnComplete(EndAttack).SetDelay(0.3f);
    }
    void EndAttack()
    {
        areHandsMoves = false;
    }
}
