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


    private void OnCollisionExit(Collision collision)
    {
        print("bum");
        asd = true;
    }

    void yukari()
    {
        if (asd)
        {
            if (transform.position.y < 0.6f)
            {
                rb.AddForce(0, 1, 0 * speed, ForceMode.Impulse);
            }
        }
    }
}
