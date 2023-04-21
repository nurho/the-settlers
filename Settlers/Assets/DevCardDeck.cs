using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stores the deck of development cards and issues them to players.
/// </summary>
public class DevCardDeck : MonoBehaviour
{
    // ----------------
    //    Variables
    // ----------------

    int cards_remaining = 25;
    List<string> deck = new List<string>();


    // ----------------
    //     Methods
    // ----------------

    /// <summary>
    /// Removes a card from the deck and returns its type.
    /// </summary>
    /// <returns>Name of the card type.</returns>
    public string draw_card() {
        if (cards_remaining > 0) {
            string card = deck[cards_remaining - 1];
            cards_remaining--;
            return card;
        } else {
            return "none";
        }
    }

    /// <summary>
    /// Randomise the order of cards in the deck.
    /// </summary>
    private void shuffle() {
        int i;
        List<string> temp_deck = new List<string>();
        foreach (string card in deck) {
            i = Random.Range(0, 1);
            if (i == 0) {
                temp_deck.Add(card);
            } else if (i == 1) {
                temp_deck.Insert(0, card);
            }
        }

        deck = temp_deck;
    }
    

    // Start is called before the first frame update
    void Start()
    {
        // Setup the deck of cards

        // Add knights
        for (int i = 0; i < 14; i++) {
            deck.Add("knight");
        }
        
        // Add progress cards
        // TODO Differentiate progress cards (different effects)
        for (int i = 0; i < 6; i++) {
            deck.Add("progress");
        }

        // Add victory point cards
        for (int i = 0; i < 5; i++) {
            deck.Add("victory");
        }

        shuffle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
