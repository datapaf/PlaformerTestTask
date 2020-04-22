using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float moveSpeed = 5f;                // the multiplier impacts on the speed of left-right movement
    public float jumpMultiplier = 1f;           // the multiplier impacts on the power of the jump
    private bool isGrounded = false;            // the boolean var necessary for jumping
    private Animator animator;                  // getting anim component to change its local variables 
    private SpriteRenderer spriteRenderer;      // getting sprite renderer component to change its local variables 

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();  
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    // Implementation of the ability to move
    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f); // get information about the direction
        
        if (movement.x < 0)
        {
            // if the player goes to the left then filp the player's sprite
            spriteRenderer.flipX = true;
        }
        else if ( movement.x > 0 )
        {
            // if the player goes to the right then turn player's sprite back
            spriteRenderer.flipX = false;
        }
        
        animator.SetFloat("Speed", Mathf.Abs(movement.x)); // change the speed to enable animation

        transform.position += movement * Time.deltaTime * moveSpeed; // change position of the player
    }

    // Implementation of the ability to move
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // if the player is on the ground and pushing jump button then apply force
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f) * jumpMultiplier, ForceMode2D.Impulse);
        }
    }

    // actions when the player touches the ground
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Enemy")
        {
            animator.SetBool("isJumping", false); // turn "isJumping" variable off to disable animation
            isGrounded = true; // allow jumping
        }
    }

    // actions when the player leaves the ground
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Enemy")
        {
            animator.SetBool("isJumping", true); // turn "isJumping" variable on to enable animation
            isGrounded = false; // restrict jumping
        }
    }
}
