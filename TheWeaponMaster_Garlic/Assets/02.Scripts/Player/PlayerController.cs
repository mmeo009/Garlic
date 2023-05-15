using UnityEngine;

public class PlayerController : GeneralAnimation
{

    float h, v;
    Vector3 moveDir;
    [SerializeField]
    float dashTime = 20.0f;
    [SerializeField]
    float nowSpeed;
    private void Start()
    {
        StatSetting(5, 5, 5.0f, 10.0f, 5.0f, 0);

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
                nowSpeed = Stats.DashSpeed;
                dashTime -= Time.deltaTime;
            }
            else
            {
                nowSpeed = Stats.MoveSpeed;
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
    }
}
