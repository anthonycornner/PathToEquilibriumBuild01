using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    // force, apply force, 1x, sends player moving upwards gravity moves player back down
    //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    [Header("Jump Details")]
    public float jumpForce;
    public float jumpTime;
    private float jumpTimeCounter;
    private bool stoppedJumping;

    [Header("Ground Details")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float radOCircle;
    [SerializeField] private LayerMask whatIsGround;
    public bool isGrounded;

    [Header("Components")]
    private Rigidbody2D rb;


    
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpTimeCounter = jumpTime;
    }

    private void Update()
    {
        // what it means to be grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position,radOCircle, whatIsGround);

        if(isGrounded )
        {
            jumpTimeCounter = jumpTime;
        }

        //if we press the space and w keys to jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //jump
            stoppedJumping = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            
        }

        // if we hold the jump button
        if (Input.GetButton("Jump") && !stoppedJumping && (jumpTimeCounter > 0))
        {
            //keep applying the same force to the jump
            rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
            jumpTimeCounter -= Time.deltaTime;
        }

        //if we release the jump button
        if (Input.GetButtonUp("Jump"))
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
        }

        
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position, radOCircle);
    }
}
