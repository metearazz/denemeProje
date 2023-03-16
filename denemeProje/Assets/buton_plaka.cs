using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buton_plaka : MonoBehaviour
{
    public bool asd = false; 

    Rigidbody rb;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        yukari();
    }
    private void OnCollisionEnter(Collision collision)
    {
        asd= false;
    }

    private void OnCollisionExit(Collision collision)
    {
       
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
