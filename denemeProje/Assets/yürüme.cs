using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yürüme : MonoBehaviour
{


    Rigidbody rb;
    public float hiz;
    public float ziplamaGucu;
    bool yerdeMi;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float hareket = Input.GetAxis("Horizontal") * Time.deltaTime * hiz;
        transform.Translate(new Vector3(hareket, 0, 0)); //zıplama
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (yerdeMi)
            {
                rb.AddForce(Vector3.up * ziplamaGucu * 250 * Time.deltaTime, ForceMode.Impulse);
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            yerdeMi = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            yerdeMi = false;
        }
    }

}
