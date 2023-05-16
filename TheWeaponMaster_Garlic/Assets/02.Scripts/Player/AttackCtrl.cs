using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCtrl : MonoBehaviour
{
    public GameObject Monster;
    public GameObject hand;
    public float maxRange;
    public Ray ray;
    public AudioClip fire1Sfx;
    new AudioSource audio;
    private void Start()
    {
        audio = GetComponent<AudioSource>();
        maxRange = 10.0f;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
    }
}
