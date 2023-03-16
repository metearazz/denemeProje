using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformScript : MonoBehaviour
{
    public bool yukari;


    // Update is called once per frame
    void Update()
    {
        if (yukari)
        {
            if (transform.position.y < 24.45f)
            {
                transform.Translate(0, 1 * Time.deltaTime, 0);
            }
        }
    }
}
