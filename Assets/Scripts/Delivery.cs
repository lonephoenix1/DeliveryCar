using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1); // Color when the object has a package.
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1); // Color when the object doesn't have a package.
    [SerializeField] float destroyDelay = 0.5f; // Delay before destroying the package after pickup.
    bool hasPackage; // Flag indicating whether the object has a package.

    SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component.

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the SpriteRenderer component.
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Ouch"); // Log collision.
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Package picked up"); // Log package pickup.
            hasPackage = true; // Set hasPackage flag.
            spriteRenderer.color = hasPackageColor; // Change color to indicate package pickup.
            Destroy(other.gameObject, destroyDelay); // Destroy the package after a delay.
        }

        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Package Delivered"); // Log package delivery.
            hasPackage = false; // Reset hasPackage flag.
            spriteRenderer.color = noPackageColor; // Change color to indicate no package.
        }
    }
}
