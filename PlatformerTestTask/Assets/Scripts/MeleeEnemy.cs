using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;      // getting sprite renderer component to change its local variables 
    public GameObject start;                    // getting the start point of the melee enemy's track
    public GameObject end;                      // getting the end point of the melee enemy's track
    public float speed = 2f;                    // the multiplier impacts on the speed of left-right movement
    private bool isEnd = false;                 // the boolean variable necessary to change the direction of the movement

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        // stop rendering lines that are necessary only in the editor
        start.GetComponent<SpriteRenderer>().enabled = false; 
        end.GetComponent<SpriteRenderer>().enabled = false; 
    }

    // Update is called once per frame
    void Update()
    {
        if ( isEnd == false )
        {
            // if the enemy has not reached the end point then move to it
            transform.position = Vector3.MoveTowards(transform.position, end.transform.position, Time.deltaTime * speed);
        }
        if ( isEnd == true )
        {
            // if the enemy has reached the end point then move to start point
            transform.position = Vector3.MoveTowards(transform.position, start.transform.position, Time.deltaTime * speed);
        }
        if ( transform.position == end.transform.position ) 
        {
            // if the enemy is in the end point then
            isEnd = true;   // the enemy has reached the end point
            spriteRenderer.flipX = true; // it should look to another direction
        }
        if (transform.position == start.transform.position)
        {
            // if the enemy is in the start point then
            isEnd = false; // the enemy has reached the start point
            spriteRenderer.flipX = false; // it should look to another direction
        }
    }
}
