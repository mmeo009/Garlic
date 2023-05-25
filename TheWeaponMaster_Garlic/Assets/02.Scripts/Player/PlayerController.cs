using UnityEngine;

public class PlayerController : CreatureStats
{
    public GameObject cam;
    float h, v;
    Vector3 moveDir;
    [SerializeField]
    float dashTime = 20.0f;
    [SerializeField]
    float nowSpeed;
    [SerializeField]
    bool isDash = false;
    private void Start()
    {
        StatSetting(5, 5.0f, 10.0f, 5.0f, 0);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        nowSpeed = Stats.MoveSpeed;
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
            }
        }
        if (dashTime < 20.0f)
        {
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                nowSpeed = Stats.MoveSpeed;
                dashTime += Time.deltaTime;
            }
        }
        if (dashTime < 0)
        {
            dashTime = 0;
        }

        transform.Translate(moveDir.normalized * nowSpeed * Time.deltaTime, Space.Self);
    }

    public void GetDMG(int dmg)
    {
        Stats.HP -= dmg;
        if (Stats.HP <= 0)
        {
            Destroy(this.gameObject);
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
            Stats.HP += hp;
            Debug.Log(Stats.HP);
        }
    }
}
