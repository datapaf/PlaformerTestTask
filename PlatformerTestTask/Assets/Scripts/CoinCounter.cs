using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

// Script for coin counter on the screen. Provides the number of taken coins to the text.

public class CoinCounter : MonoBehaviour
{
    private int counter;            // the number of taken coins
    public GameObject coin1;        // the gameobject of the first coin is necessary to check whether it is taken
    private bool isCoin1Counted;    // the bool var for the first coin is necessary to check whether it has already been counted by the counter
    public GameObject coin2;        // the gameobject of the second coin is necessary to check whether it is taken
    private bool isCoin2Counted;    // the bool var for the second coin is necessary to check whether it has already been counted by the counter
    public GameObject coin3;        // the gameobject of the third coin is necessary to check whether it is taken
    private bool isCoin3Counted;    // the bool var for the third coin is necessary to check whether it has already been counted by the counter

    // Start is called before the first frame update
    void Start()
    {
        counter = 0; // initially the number of taken coins is zero
        isCoin1Counted = false; // first coin is not counted
        isCoin2Counted = false; // second coin is not counted
        isCoin3Counted = false; // third coin is not counted
    }

    // Update is called once per frame
    void Update()
    {
        if (coin1.GetComponent<Coin>().isTaken && isCoin1Counted == false) {
            // if the player has taken the first coin and it is not counted then count it
            isCoin1Counted = true;
            counter += 1;
            gameObject.GetComponent<Text>().text = "Coins: " + counter.ToString();
        }
        if(coin2.GetComponent<Coin>().isTaken && isCoin2Counted == false) {
            // if the player has taken the second coin and it is not counted then count it
            isCoin2Counted = true;
            counter += 1;
            gameObject.GetComponent<Text>().text = "Coins: " + counter.ToString();
        }
        if (coin3.GetComponent<Coin>().isTaken && isCoin3Counted == false)
        {
            // if the player has taken the third coin and it is not counted then count it
            isCoin3Counted = true;
            counter += 1;
            gameObject.GetComponent<Text>().text = "Coins: " + counter.ToString();
        }
    }
}
