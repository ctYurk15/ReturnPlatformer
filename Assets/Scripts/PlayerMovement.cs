using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float jump = 5f;
    [Space]
    [SerializeField] string enemyHead = "Enemy head";
    [Space]
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    [Space]
    [SerializeField] AudioSource jumpSound;

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
            Jump();
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jump, rb.velocity.z);
        jumpSound.Play();
    }

    bool IsGrounded()
    {
        //checks if groundCheck with collider of shpere with .1f radius overlaps with objects, that has ground layer
        return Physics.CheckSphere(groundCheck.position, 0.1f, ground);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == enemyHead)
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }
}
