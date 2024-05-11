using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float destroyDelay = 0.5f;
    bool hasPckage;
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ouch");
    }

    void OnTriggerEnter2D(Collider2D Delivery)
    {
        if (Delivery.tag == "Package" && !hasPckage)
        {
            Debug.Log("Package picked up");
            hasPckage = true;
            Destroy(Delivery.gameObject, destroyDelay);
        }

        if (Delivery.tag == "Customer" && hasPckage)
        {
            Debug.Log("Package Delivered");
            hasPckage = false;
        }
    }
}
