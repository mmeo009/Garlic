using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public void L1()
    {
        SceneManager.LoadScene("Lv_1");
    }
    public void L2()
    {
        SceneManager.LoadScene("Lv_2");
    }
    public void L3()
    {
        SceneManager.LoadScene("Lv_3");
    }

    public GameObject B1, B2, B3;
    float rain;
    public int type;
    public void Start()
    {
        rain = Random.Range(-21.0f, 21.0f);
        type = Random.Range(0, 3);

    }

    void Update()
    {

        for (int i = 0; i < 20; ++i)
        {
            switch(type)
            {
                case 0:
                    GameObject B1R = (GameObject)Instantiate(B1);
                    B1R.transform.position = new Vector3(rain, 10, 0);
                    break;
                case 1:
                    GameObject B2R = (GameObject)Instantiate(B2);
                    B2R.transform.position = new Vector3(rain, 10, 0);
                    break;
                case 2:
                    GameObject B3R = (GameObject)Instantiate(B3);
                    B3R.transform.position = new Vector3(rain, 10, 0);
                    break;
            }
            type = Random.Range(0, 3);
            rain = Random.Range(-21.0f, 21.0f);
        }
    }
}
