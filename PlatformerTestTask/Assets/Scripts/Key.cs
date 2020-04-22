using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for the key to the exit door. 
//Just showing that the key has been picked up 

public class Key : MonoBehaviour
{
    public bool isTaken;    // the bool var indicating whether the key was taken

    // Start is called before the first frame update
    void Start()
    {
        isTaken = false; // initially the key is not taken
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            // if there is collision with the player then
            isTaken = true; // the key is taken now
            gameObject.SetActive(false); // make the key disappear
        }
    }
}
