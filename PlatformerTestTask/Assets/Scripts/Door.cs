using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

// Script for the exit door. Becomes open when the key is picked up.

public class Door : MonoBehaviour
{
    public GameObject key;          // the gameobject of the key is necessary to check whether it was taken
    private bool isOpen;            // the bool var for the door is needed to know whether the door is open or closed
    public Sprite spriteOpen;       // we will change the sprite of the door to the sprite of a open door 
    public Sprite spriteClosed;     // when the door is closed it should have the sprite of a closed door
    public Text LevelCompleteText;  // the object of the LevelCompleteText is needed to show it
     
    // Start is called before the first frame update
    void Start()
    {
        isOpen = false; // the door is closed in the beginning
        gameObject.GetComponent<SpriteRenderer>().sprite = spriteClosed; // the door has the sprite of a closed door
        LevelCompleteText.enabled = false;  // the final text is hidden
    }

    // Update is called once per frame
    void Update()
    {
        if ( key.gameObject.GetComponent<Key>().isTaken ) {
            // if the key has been taken then 
            isOpen = true; // open the door
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteOpen; // and set up the sprite of an open door
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && isOpen)
        {
            // if the player is at the door and it is open then
            LevelCompleteText.enabled = true; // shoe the text that the level is complete
        }
    }
}
