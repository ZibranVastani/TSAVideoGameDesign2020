using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    private float jumpForce = 150f;
    private Rigidbody rb;
    private bool isGrounded; // Check if obstacle touch the ground


    // Use this for initialization
    void Start()
    {
        isGrounded = true;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isGrounded == true)
        {
            rb.AddForce(transform.up * jumpForce);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Ground") // you must add collider to ground 
        {
            isGrounded = true;
        }
    }

}
