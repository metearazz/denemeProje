using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class yürüme : MonoBehaviour
{
    public Animator animator2;

    public static yürüme instance;

    public bool isDead = false;

    bool sagBak;

    // Duman efekti için ön tanımlı bir prefab
    public GameObject smokePrefab;

    // Duman efektinin ne kadar süreceği
    public float smokeDuration = 0.3f; 

    Rigidbody rb;
    public float hiz;
    public float ziplamaGucu;
    bool yerdeMi;

    // Layer işlemi için
    public string layerToIgnore = "Oyuncu"; 

   

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

        float hareket = Input.GetAxis("Horizontal") * hiz;
        Vector3 hareketVektoru = new Vector3(hareket, 0, 0);

        // hareket vektörünü karakterin yönüne dönüştür
        hareketVektoru = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * hareketVektoru;

        // karakteri hareket ettir
        rb.velocity = new Vector3(hareketVektoru.x, rb.velocity.y, 0);

        #region Karakter çevirme 

        if (hareket < 0 && !sagBak)
            Rotate();


        if (hareket > 0 && sagBak)
            Rotate();

        #endregion

        #region Animasyon

        if (hareket > 0 || hareket < 0)
            animator2.SetBool("isRunning", true);
        else
            animator2.SetBool("isRunning", false);

        #endregion

        #region Zıplama
        if (Input.GetKeyDown(KeyCode.UpArrow) && yerdeMi)
        {
            rb.AddForce(Vector3.up * ziplamaGucu, ForceMode.Impulse);
            // karakterin havada olduğunu işaretle
            yerdeMi = false;
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
        if (other.gameObject.name == "Su" || other.gameObject.name == "Zehir")
        {
            GameObject smoke = Instantiate(smokePrefab, transform.position, Quaternion.identity);

            // Duman efekti belirtilen süre boyunca kalacak
            Destroy(smoke, smokeDuration);
            print("Ateş Yandı");
            Destroy(gameObject);
            isDead = true;
        }
        if (other.gameObject.tag == "KirmiziElmas")
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 6)
            yerdeMi = true;

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 6)
            yerdeMi = false;

    }
}

