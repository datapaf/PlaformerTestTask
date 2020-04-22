using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Script for a coin. The coin becomes taken after collision with player

public class Coin : MonoBehaviour
{
    public bool isTaken;

    // Start is called before the first frame update
    void Start()
    {
        isTaken = false; // initially the coin is not picked up
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            // if a collision with player happens then
            isTaken = true; // the coin becomes taken
            gameObject.SetActive(false); // the coin itself disappears
        }
    }
}
