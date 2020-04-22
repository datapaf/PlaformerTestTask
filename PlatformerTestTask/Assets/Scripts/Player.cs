using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Health = 100;    // the variable demonstrates the number of health points
    private Animator animator;  // getting anim component to change its local variables 

    // the procedure performing action when dying
    void Death()
    {
        animator.SetBool("isDead", true); // turn "isDead" variable on to enable animation
        gameObject.GetComponent<Moving>().enabled = false; // when the player is dying he cannot move
    }

    // Event of restarting the level after animation
    void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Event of disappearing after death animation
    void Disappear()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    // the function applying damage to the player
    void TakeDamage(int damagePoints)
    {
        Health = Health - damagePoints;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0) {
            Death(); // if the player has no health point then he is dead
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy") {
            TakeDamage(100); // when the player collides with enemy then he takes mortal damage
        }
    }

    // the function similar to OnTriggerEnter2D. Needed to damage player by the enemies with not-trigger colliders 
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            TakeDamage(100); // when the player collides with enemy then he takes mortal damage
        }
    }
}
