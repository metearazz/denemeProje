using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class yürümeSu : MonoBehaviour
{
    public Animator animator;

    public static yürümeSu instance;

    public bool isDead = false;

    bool sagBak;

    public GameObject smokePrefab;

    public float smokeDuration;

    Rigidbody rb;
    public float hiz;
    public float ziplamaGucu;
    bool yerdeMi;


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
        float hareket = Input.GetAxis("Vertical") * hiz;

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
        animator.SetBool("run", true);

        else
        animator.SetBool("run", false);

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
    
            isDead = true;
        }
        if (other.gameObject.tag == "MaviElmas")
        {
           
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
