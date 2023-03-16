using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class salter : MonoBehaviour
{
    public GameObject platform;

    bool acikMi;



    // Update is called once per frame
    void Update()
    {


        if (transform.rotation.eulerAngles.z < 90f)
        {
            acikMi = true;
        }
        else
        {
            acikMi = false;
        }

        if (acikMi)
        {
            if (platform.transform.position.y > 16.5f)
            {
                platform.transform.Translate(0, -1 * Time.deltaTime, 0);
            }
           
        }
        else
        {
             if (platform.transform.position.y < 20.1f)
            {
                platform.transform.Translate(0, 1 * Time.deltaTime, 0);
            }
        }


    }
}
