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
                rb.AddForce(Vector3.up * ziplamaGucu , ForceMode.Impulse);
            }
        }
    }
    //void Hareket()
    //{
    //    float moveX = Input.GetAxis("Horizontal"); // Get horizontal input axis value (-1 to 1)

    //    Vector3 movement = new Vector3(moveX, 0f, 0f); // Create movement vector with only x-axis movement
    //    rb.velocity = movement * hiz; // Set Rigidbody velocity to movement vector multiplied by speed
    //}

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
