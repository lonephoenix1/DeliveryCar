using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverController : MonoBehaviour
{
    // Speed of steering
    [SerializeField] float steerSpeed = 1f;

    // Base movement speed
    [SerializeField] float moveSpeed = 20f;

    // Speed when colliding with obstacles
    [SerializeField] float slowSpeed = 15f;

    // Speed when boosted
    [SerializeField] float boostSpeed = 30f;

    void Start()
    {
        // Initialization code goes here
    }

    void Update()
    {
        // Calculate steering amount based on player input
        float steerAmount = 0f;
        if (Input.GetAxis("Vertical") != 0)
        {
            steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        }

        // Apply rotation based on steering input around the z-axis
        transform.Rotate(0, 0, -steerAmount);

        // Calculate forward movement amount based on player input
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // Convert forward movement to a vector in the car's local space
        Vector3 moveVector = transform.up * moveAmount;

        // Apply translation based on movement input
        transform.position += moveVector;
    }

    // Handle collision events
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Reduce speed when colliding with obstacles
        moveSpeed = slowSpeed;
    }

    // Handle trigger events
    void OnTriggerEnter2D(Collider2D ExtraSpeed)
    {
        // Increase speed when triggered by a boost pickup
        if (ExtraSpeed.tag == "Boost")
        {
            moveSpeed = boostSpeed;
        }
    }
}




