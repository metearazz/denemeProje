using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yürümeSu : MonoBehaviour
{
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
        float hareket = Input.GetAxis("Vertical") * hiz;
        Vector3 hareketVektoru = new Vector3(hareket, 0, 0);
        hareketVektoru = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * hareketVektoru; // hareket vektörünü karakterin yönüne dönüştür

        rb.velocity = new Vector3(hareketVektoru.x, rb.velocity.y, 0); // karakteri hareket ettir

        if (Input.GetKeyDown(KeyCode.W))
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
