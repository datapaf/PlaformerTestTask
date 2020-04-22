using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for the ranged enemy.
// Necessary to make periodic booms

public class RangedEnemy : MonoBehaviour
{
    public GameObject Explosion;        // the gameobject of the explosion part is needed to make it appear and disappear
    public GameObject Projectile;       // the gameobject of the pojectile part is needed to make it appear and disappear
    public float TimeMin = 5f;          // the minimal delta time to make a shot
    public float TimeMax = 10f;         // the maximal delta time to make a shot

    public float TargetTime;            // the delta time determined randomly from the range
    private float timer;                // the timer to count the time to make a shot

    // Start is called before the first frame update
    void Start()
    {
        TargetTime = Random.Range(TimeMin,TimeMax); // calculating the delta time from the range 
        Explosion.SetActive(false); // the explosion initially should not appear
        Projectile.SetActive(false); // the projectile initially should not appear
        timer = TargetTime; // set up the timer
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0.0f)
        {
            // if the time is up then
            Explosion.SetActive(true); // there the explosion comes
            TargetTime = Random.Range(TimeMin, TimeMax); // choose the new delta time
            timer = TargetTime; // set up the timer
        }
        else 
        {
            // if the timer is ticking
            timer = timer - Time.deltaTime; // continue to count
        }
    }
}
