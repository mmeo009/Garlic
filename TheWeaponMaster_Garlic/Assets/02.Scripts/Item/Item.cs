using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemType;
    public int dmgP = 1;
    public float speedP = 5;
    public int healP = 1;

    void Start()
    {
        if (this.gameObject.tag == "Item_1")
        {
            itemType = 1;
        }
        else if (this.gameObject.tag == "Item_2")
        {
            itemType = 2;
        }
        else if (this.gameObject.tag == "Item_3")
        {
            itemType = 3;
        }
        else
        {
            itemType = 4;
            Debug.Log("뭔가 이상하다!");
        }
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            switch (itemType)
            {
                case 1:
                    other.gameObject.GetComponent<AttackCtrl>().StatPlus(1, dmgP);
                    Destroy(this.gameObject);
                    break;
                case 2:
                    other.gameObject.GetComponent<PlayerController>().StatPlus(2, speedP, 0);
                    Destroy(this.gameObject);
                    break;
                case 3:
                    other.gameObject.GetComponent<PlayerController>().StatPlus(3, 0, healP);
                    Destroy(this.gameObject);
                    break;
                case 4:
                    Debug.Log("이상하다니까?");
                    Destroy(this.gameObject);
                    break;

            }
        }
    }
}
