using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for the projectile part of the ranged enemy. 
// Basically the script performs moving 

public class Projectile : MonoBehaviour
{
    public GameObject launcher;         // the gameobject of the launcher is necessary to determine the direction of moving
    public float speed = 2f;            // the speed of the moving projectile
    public float TimeToDisappear;       // after what amount of time we need to destroy thr projectile

    private bool appear = true;         // the bool var determining whether it is allowed to projectile to appear
    private Vector3 direction;          // the direction of moving
    private Vector3 initialPosition;    // initial coordinates of the projectile to bring it back afterwards
    public float timer;                 // the timer to perform periodic shots

    // Start is called before the first frame update
    void Start()
    {
        timer = TimeToDisappear; // set up timer
        initialPosition = transform.position;   // get the initial position
        // get the difference between the x-coordinates of the projectile and the launcher
        float differenceX = transform.position.x - launcher.transform.position.x; 
        direction = new Vector3(Mathf.Abs(differenceX)/differenceX, 0f, 0f); // get the exact diraction
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0.0f || appear == false)
        {
            // when the time is up of the projectile has to diappear then
            transform.position = initialPosition; // return back the projectile
            timer = TimeToDisappear;    // set up the timer again
            gameObject.SetActive(false); // disable the pojectile 
            appear = true; // the projectile is ready to appear
        }
        else
        {
            // when the pjectile may exist then
            timer = timer - Time.deltaTime; // continue counting
            transform.position += direction * Time.deltaTime * speed; // move the projectile
        }
    }

    void OnCollisionEnter2D()
    {
        appear = false; // if the projectile collided with something it shoud disappear
    }
}
