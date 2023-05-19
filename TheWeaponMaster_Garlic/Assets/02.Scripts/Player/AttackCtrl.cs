using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackCtrl : MonoBehaviour
{
    public GameObject Monster;
    public GameObject hand;
    public GameObject type1;
    public GameObject type2;
    public Camera viewCamera;

    public float maxRange;
    public Ray ray;
    public AudioClip fire1Sfx;
    new AudioSource audio;
    public Vector3 targetPosition;
    public bool isAttack;
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
        type2P = new Vector3(hand.transform.position.x /*+ 1.07f*/, hand.transform.position.y /*-0.64f*/, hand.transform.position.z /*+0.76f*/);
        {

        };
        Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
        targetPosition = new Vector3(mousePos.x, mousePos.y, mousePos.z);
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
                        hit.collider.gameObject.GetComponent<MonsterController>().GetDmg(1);
                    }
                    Debug.Log(hit.collider.name);
                }
            }
            if(type == WeponType.Sword)
            {
                if (isAttack == false)
                {
                    SwordAttack();
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
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            type= WeponType.Dagger;
        }
    }

    void SwordAttack()
    {
        type2.transform.DOJump(targetPosition, 1.0f, 2, 1.0f).OnComplete(HandBack);
    }
    void HandBack()
    {
        type2.transform.DOMove(type2P, 1).OnComplete(SwordEndAttack).SetDelay(0.3f);
    }
    void SwordEndAttack() 
    { }

}
