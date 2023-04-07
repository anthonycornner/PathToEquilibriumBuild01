using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    // force, apply force, 1x, sends player moving upwards gravity moves player back down
    //rb.velocity = new Vector2(rb.velocity.x, jumpForce);

    public float jumpForce;
    public bool isGrounded;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle();
        //use space and w keys to jump respectively
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
