using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 50f; // The speed of the projectile

    void Start()
    {
        // Apply initial velocity to the projectile
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }


    void OnCollisionEnter(Collision collision)
    {
        // Optional: Add collision handling code if needed
        // For example, you can add code to destroy the projectile upon collision with another object.
        Destroy(gameObject);
    }
}