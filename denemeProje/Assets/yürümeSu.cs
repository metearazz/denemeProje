using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class yürümeSu : MonoBehaviour
{
    public static yürümeSu instance;

    public bool isDead = false;
    
    bool sagBak;

    public Animator animator;

    public GameObject smokePrefab; // Duman efekti için ön tanımlı bir prefab
    public float smokeDuration; // Duman efektinin ne kadar süreceği
    Rigidbody rb;
    public float hiz;
    public float ziplamaGucu;
    bool yerdeMi;
    public string layerToIgnore = "Oyuncu"; // Set the layer to ignore collisions with here

    private void Awake()
    {
        instance = this;
    }

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


        #region Karakter çevirme 

        if (hareket < 0 && !sagBak)
        {
            Rotate();
        }

        if (hareket > 0 && sagBak)
        {
            Rotate();
        }
        #endregion

        #region Animasyon

        if (hareket > 0 || hareket < 0)
        {
            animator.SetBool("run", true);
        }

        else
        {
            animator.SetBool("run", false);
        }
        #endregion

        #region Zıplama
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (yerdeMi)
            {
                rb.AddForce(Vector3.up * ziplamaGucu, ForceMode.Impulse);
                yerdeMi = false; // karakterin havada olduğunu işaretle
            }
        }
        #endregion
    }

    void Rotate()
    {
        sagBak = !sagBak;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Ates" || other.gameObject.name == "Zehir")
        {
            GameObject smoke = Instantiate(smokePrefab, transform.position, Quaternion.identity);

            // Duman efekti belirtilen süre boyunca kalacak
            Destroy(smoke, smokeDuration);
            print("Su Yandı");
            Destroy(gameObject);
            //Time.timeScale = 0;
            isDead = true;
        }
        if (other.gameObject.tag == "MaviElmas")
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
