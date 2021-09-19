using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float jump = 5f;
    [Space]
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //moving
        rb.velocity = new Vector3(horizontalInput * speed, rb.velocity.y, verticalInput * speed);

        //jumping
        if(Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
        }
    }

    bool IsGrounded()
    {
        //checks if groundCheck with collider of shpere with .1f radius overlaps with objects, that has ground layer
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);
    }
}
