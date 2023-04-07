using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

// give player object physics to move left and right, jump will be in a different script

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    // necessary for animations and physics
    private Rigidbody2D rb2D;
    private Animator myAnimator;
    private bool facingRight = true;

    // variables to play with
    public float speed = 2.0f;
    public float horizMovement; // = 1 or -1 or 0

    private void Start()
    {
        // define the game objects found on the player
        rb2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    // handles the input for physics
    private void Update()
    {
        // check direction given by player
        horizMovement = Input.GetAxisRaw("Horizontal");
    }  

    // handles running the physics
    private void FixedUpdate() 
    {
        // move the character left and right
        rb2D.velocity = new Vector2(horizMovement * speed, rb2D.velocity.y);
        myAnimator.SetFloat("speed", Mathf.Abs(horizMovement));

        Flip(horizMovement);
    }

    // flip character on y axis to "turn" them from right to left
    private void Flip(float horizontal)
    {
        if ((horizontal < 0 && facingRight) || (horizontal > 0 && !facingRight))
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}