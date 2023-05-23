using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

public class Mon001Ctrl : MonsterController
{

    public float rotationSpeed = 10;

    public float time = 4.0f;

    public bool areHandsMoves;

    public GameObject me;
    public GameObject hands;
    public Transform player;
    public Rigidbody rb;

    public Sequence sequenceLoop;

    public Vector3 targetDiraction;


    void Start()
    {
        StatSetting(7, 1, 3.0f, 7.0f, 5.0f, 1);
        Debug.Log(Stats.HP);
        rb = GetComponent<Rigidbody>();
        me = this.gameObject;
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
            me.transform.rotation = Quaternion.Lerp(me.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
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
    void EndAttack()
    {
        areHandsMoves = false;
    }
}
