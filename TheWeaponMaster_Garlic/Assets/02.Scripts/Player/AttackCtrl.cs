using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackCtrl : PlayerController
{
    public GameObject monster, hand, type1, type2;
    public Camera viewCamera;

    public float maxRange;
    public int dmg = 2;
    public bool isAttack;
    public Ray ray;
    public AudioClip fire1Sfx;
    new AudioSource audio;
    public Vector3 targetPosition;
    public Vector3 targetPosition2;
    public Vector3 type2P;
    public enum WeponType
    {
        Gun,
        Sword,
        Dagger
    }

    WeponType type = WeponType.Gun;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
        maxRange = 10.0f;
    }
    void Update()
    {
        type2P = new Vector3(hand.transform.position.x, hand.transform.position.y , hand.transform.position.z);
        {

        };
        Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
        targetPosition = new Vector3(mousePos.x, mousePos.y, mousePos.z);
        targetPosition2 = new Vector3(mousePos.x, mousePos.y - 2, mousePos.z);
        if (Input.GetMouseButtonDown(0))
        {
            if (type == WeponType.Gun)
            {
                Ray cast = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                audio.PlayOneShot(fire1Sfx, 3.0f);
                if (Physics.Raycast(cast, out hit))
                {
                    if (hit.collider.tag == "Monster")
                    {
                        hit.collider.gameObject.GetComponent<MonsterController>().GetDmg(dmg/2);
                    }
                    Debug.Log(hit.collider.name);
                }
            }
            if(type == WeponType.Sword)
            {
                if (isAttack == false)
                {
                    SwordAttack();
                    isAttack = true;
                }
            }
            /*            
            ray = new Ray();
            ray.origin = hand.transform.position;
            ray.direction = hand.transform.TransformDirection(Vector3.forward);
            if (Physics.Raycast(ray.origin,ray.direction,out hit,maxRange))
            {
                if (hit.collider.tag == "Monster")
                {
                    hit.collider.gameObject.GetComponent<MonsterController>().GetDmg(1);
                }
                Debug.Log(hit.collider.name);
            }
            */
        }
        if(Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            type = WeponType.Gun;
            type1.gameObject.SetActive(true);
            type2.gameObject.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            type= WeponType.Sword;
            type1.gameObject.SetActive(false);
            type2.gameObject.SetActive(true);
        }
/*        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            type= WeponType.Dagger;
        }*/
    }

    void SwordAttack()
    {
        type2.transform.DOJump(targetPosition, 1.0f, 2, 0.3f).OnComplete(HandBack);
    }
    void HandBack()
    {
        type2.transform.DOMove(hand.transform.position, 0.1f).OnComplete(SwordEndAttack);
    }
    void SwordEndAttack() 
    {
        isAttack = false;
    }

}
