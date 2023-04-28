using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls a player UI panel.
/// </summary>
public class PlayerUIController : MonoBehaviour
{
    // ----------------
    //   Variables
    // ----------------

    string player_name;

    // Declare references to other objects/scripts (set in start method)
    PlayerController player;

    Text roads;
    Text army;
    Text cards;

    


    // ----------------
    //     Methods
    // ----------------

    /// <summary>
    /// Updates the player UI with current values.
    /// </summary>
    public void update_values() {
        roads.text = player.roads_placed.ToString();
        army.text = player.knight_count.ToString();
        cards.text = (player.get_total_resources() + player.dev_cards.Count).ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        player_name = this.gameObject.name;

        // Find objects
        if (!(Game.num_players == 3 && player_name == "Player_4")) {
            player = this.gameObject.GetComponent<PlayerController>();

            roads = GameObject.Find(player_name + "Roads").GetComponent<Text>();
            army = GameObject.Find(player_name + "Army").GetComponent<Text>();
            cards = GameObject.Find(player_name + "Cards").GetComponent<Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}