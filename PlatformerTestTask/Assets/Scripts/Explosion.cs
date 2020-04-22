using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for the explosion part of the ranged enemy. 
//The script is needed to perform events during explosion animation

public class Explosion : MonoBehaviour
{
    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Event of launching the projectile
    void LaunchProjectile()
    {
        // to launch the projectile we just make is active
        projectile.SetActive(true);
    }

    // Event of turning the explosion off
    void DisableExplosion()
    {
        // to disable the explosion we just deactivate it
        gameObject.SetActive(false);
    }
}
