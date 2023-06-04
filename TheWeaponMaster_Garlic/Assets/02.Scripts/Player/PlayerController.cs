using UnityEngine;

public class PlayerController : CreatureStats
{
    public GameObject cam;
    float h, v;
    Vector3 moveDir;
    public float dashTime;
    [SerializeField]
    float nowSpeed;
    [SerializeField]
    bool isDash = false;
    bool cantDash = false;
    public int maxHp = 5;
    public int nowHp;
    public AudioClip fire1Sfx;
    public AudioClip fire2Sfx;
    public AudioClip stepSfx;
    public AudioClip hitSfx;
    public new AudioSource audio;
    private void Start()
    {
        StatSetting(5, 5.0f, 10.0f, 5.0f, 0);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        audio = GetComponent<AudioSource>();
        nowSpeed = Stats.MoveSpeed;
        nowHp = Stats.HP;
    }
    private void FixedUpdate()
    {
        if(this.transform.position.y <= -3)
        {
            this.transform.position = new Vector3(0, 2, 0);
        }
    }
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        moveDir = (Vector3.forward * v) + (Vector3.right * h);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (dashTime > 0)
            {
                nowSpeed = Stats.Stat2;
                dashTime -= Time.deltaTime;
                isDash = true;
            }
            else
            {
                nowSpeed = Stats.MoveSpeed;
                isDash= false;
                cantDash = true;
            }
        }
        if (dashTime < 20.0f)
        {
            if (!Input.GetKey(KeyCode.LeftShift) && (isDash == false || cantDash == false))
            {
                nowSpeed = Stats.MoveSpeed;
                dashTime += Time.deltaTime;
            }
        }
        transform.Translate(moveDir.normalized * nowSpeed * Time.deltaTime, Space.Self);
    }
    private void LateUpdate()
    {
        nowHp = Stats.HP;
        if (dashTime < 0)
        {
            dashTime = 0;
        }
        if (dashTime >= 20.0f)
        {
            dashTime = 20.0f;
        }
    }


    public void GetDMG(int dmg)
    {
        Stats.HP -= dmg;
        if (Stats.HP <= 0)
        {
            Destroy(this.gameObject);
            audio.PlayOneShot(hitSfx, 15.0f);
        }
        Debug.Log(Stats.HP);
        //cam.GetComponent<CamController>().Knock(dmg);
    }
    public void StatPlus(int type, float p, int hp)
    {
        if (type == 2)
        {
            Stats.MoveSpeed += p;
            Stats.Stat2 += p;
            if (isDash == false)
            {
                nowSpeed = Stats.MoveSpeed;
            }
            else if (isDash)
            {
                nowSpeed = Stats.Stat2;
            }
        }
        else if (type == 3)
        {
            if (Stats.HP == maxHp)
            {
                Stats.HP += hp;
                maxHp += hp;
            }
            else
            {
                Stats.HP += hp;
            }
            Debug.Log("최대 : " + maxHp + "/ 지금 :" + Stats.HP);
        }
    }
}
