using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elmas : MonoBehaviour
{
    public float rotateSpeed;

    void Update()
    {
        transform.Rotate(0, 0, 1 * rotateSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
