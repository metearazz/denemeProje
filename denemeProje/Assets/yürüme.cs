using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class yürüme : MonoBehaviour
//{
//    public CharacterController controller;
//    public float speed;
//    public float ziplamaGucu;
//    public float gravity;
//    Vector3 velocity;

//    private void Update()
//    {
//        float yatay = Input.GetAxis("Horizontal");

//        Vector3 direction = new Vector3(yatay, 0, 0).normalized;
//        if (direction.magnitude >= 0.1f)
//        {
//            controller.Move(direction * speed * Time.deltaTime);
//        }
//        velocity.y += gravity * Time.deltaTime;
//        controller.Move(velocity * Time.deltaTime);


//        if (controller.isGrounded) // karakter yerdeyse
//        {
//            if (Input.GetKeyDown(KeyCode.UpArrow))
//            {
//                controller.Move(Vector3.up * ziplamaGucu * Time.deltaTime); // karakteri zıplat
//            }
//        }
//    }
//}

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
        float hareket = Input.GetAxis("Horizontal") * hiz;
        Vector3 hareketVektoru = new Vector3(hareket, 0, 0);
        hareketVektoru = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * hareketVektoru; // hareket vektörünü karakterin yönüne dönüştür

        rb.velocity = new Vector3(hareketVektoru.x, rb.velocity.y, 0); // karakteri hareket ettir

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (yerdeMi)
            {
                rb.AddForce(Vector3.up * ziplamaGucu, ForceMode.Impulse);
                yerdeMi = false; // karakterin havada olduğunu işaretle
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            yerdeMi = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            yerdeMi = false;
        }
    }
}



//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class yürüme : MonoBehaviour
//{


//    Rigidbody rb;
//    public float hiz;
//    public float ziplamaGucu;
//    bool yerdeMi;

//    private void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//    }

//    private void Update()
//    {
//        float hareket = Input.GetAxis("Horizontal") * Time.deltaTime * hiz;
//        transform.Translate(new Vector3(hareket, 0, 0)); //zıplama
//        if (Input.GetKeyDown(KeyCode.UpArrow))
//        {
//            if (yerdeMi)
//            {
//                rb.AddForce(Vector3.up * ziplamaGucu, ForceMode.Impulse);
//            }
//        }
//    }

//    private void OnCollisionStay(Collision collision)
//    {
//        if (collision.gameObject.tag == "platform")
//        {
//            yerdeMi = true;
//        }
//    }

//    private void OnCollisionExit(Collision collision)
//    {
//        if (collision.gameObject.tag == "platform")
//        {
//            yerdeMi = false;
//        }
//    }

//}
