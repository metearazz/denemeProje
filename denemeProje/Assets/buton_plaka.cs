using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buton_plaka : MonoBehaviour
{
    public bool asd = false;

    public GameObject platform;
    public float speed;

    platformScript p;
    private void Start()
    {
        p = platform.GetComponent<platformScript>();
    }
    private void Update()
    {
        yukari();

        if (transform.position.y < 21.89f)
        {
            if (platform.transform.position.y > 19.97f)
            {
                platform.transform.Translate(0, -1 * Time.deltaTime, 0);
            }

        }
        //else
        //{
        //    if (platform.transform.position.y < 24.45f)
        //    {
        //        platform.transform.Translate(0, 1 * Time.deltaTime, 0);
        //    }
        //}

    }
    private void OnCollisionEnter(Collision collision)
    {
        
        p.yukari = false;
        asd = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        p.yukari = true;
        asd = true;
    }

    void yukari()
    {
        if (asd)
        {
            if (transform.position.y < 22f)
            {
                transform.Translate(0, 0, 1 * Time.deltaTime);
            }
        }
    }
}
