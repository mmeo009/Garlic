using DG.Tweening;
using UnityEngine;


public class Mon001Ctrl : MonsterController
{

    public float speed = 3;
    public float rotationSpeed = 10;

    public float time = 4.0f;

    [SerializeField]
    private bool handsAreMoved;

    public GameObject me;
    public GameObject hands;
    public Transform player;
    public Rigidbody rb;

    public Sequence sequenceLoop;

    public Vector3 targetDiraction;

    Tweener handmove;

    void Start()
    {
        StatSetting(40, 1, 5.0f, 7.0f, 5.0f, 1);
        Debug.Log(Stats.HP);
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sequenceLoop = DOTween.Sequence();
    }
    void Update()
    {

        if (player != null)
        {

            targetDiraction = (player.position - me.transform.position).normalized;

            Quaternion targetRotation = Quaternion.LookRotation(targetDiraction);

            if (handsAreMoved == false)
            {
                if (Vector3.Distance(player.position, transform.position) > 5)
                //Vecter3.Distance (거리를 알려주는 함수)
                {
                    Vector3 direction = (player.position - transform.position).normalized;
                    rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
                }
                
            }
            me.transform.rotation = Quaternion.Lerp(me.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void LateUpdate()
    {
        if (Vector3.Distance(player.position, transform.position) <= 5)
        {
            if (handsAreMoved == false)
            {

                handsAreMoved = true;
                StartAttack();
            }
        }
    }
    void StartAttack()
    {
        targetDiraction = (player.position - transform.position).normalized;
        handmove = hands.transform.DOMove(targetDiraction, 3);
        handmove.OnComplete(HandBack).Restart();
    }
    void HandBack()
    {
        hands.transform.DOMove(me.transform.position, 3).OnComplete(EndAttack);
    }
    void EndAttack()
    {
        handsAreMoved = false;
    }
}
