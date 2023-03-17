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
    public GameObject smokePrefab; // Duman efekti için ön tanımlı bir prefab
    public float smokeDuration = 0.3f; // Duman efektinin ne kadar süreceği
    Rigidbody rb;
    public float hiz;
    public float ziplamaGucu;
    bool yerdeMi;
    public string layerToIgnore = "Oyuncu"; // Set the layer to ignore collisions with here


    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        int layerToIgnoreIndex = LayerMask.NameToLayer(layerToIgnore);
        Physics.IgnoreLayerCollision(layerToIgnoreIndex, layerToIgnoreIndex);
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Su" || other.gameObject.name == "Zehir")
        {
            GameObject smoke = Instantiate(smokePrefab, transform.position, Quaternion.identity);

            // Duman efekti belirtilen süre boyunca kalacak
            Destroy(smoke, smokeDuration);
            print("Ateş Yandı");
            Destroy(gameObject);

            //Time.timeScale = 0;
        }
        if (other.gameObject.tag == "KirmiziElmas")
        {
            print("girdi");
            Destroy(other.gameObject);
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
