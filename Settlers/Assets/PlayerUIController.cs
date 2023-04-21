using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    UnityEngine.UI.Text victory_points;
    UnityEngine.UI.Text lumber;
    UnityEngine.UI.Text wool;
    UnityEngine.UI.Text ore;
    UnityEngine.UI.Text grain;
    UnityEngine.UI.Text brick;


    // ----------------
    //     Methods
    // ----------------

    /// <summary>
    /// Updates the player UI with current values.
    /// </summary>
    public void update_values() {
        victory_points.text = player.victory_points.ToString();
        lumber.text = player.lumber.ToString();
        wool.text = player.wool.ToString();
        ore.text = player.ore.ToString();
        grain.text = player.grain.ToString();
        brick.text = player.brick.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        player_name = this.gameObject.name;

        // Find objects
        if (!(Game.num_players == 3 && player_name == "Player_4")) {
            player = this.gameObject.GetComponent<PlayerController>();
            victory_points = GameObject.Find(player_name + "_Victory_Points").GetComponent<UnityEngine.UI.Text>();
            lumber = GameObject.Find(player_name + "_Lumber").GetComponent<UnityEngine.UI.Text>();
            wool = GameObject.Find(player_name + "_Wool").GetComponent<UnityEngine.UI.Text>();
            ore = GameObject.Find(player_name + "_Ore").GetComponent<UnityEngine.UI.Text>();
            grain = GameObject.Find(player_name + "_Grain").GetComponent<UnityEngine.UI.Text>();
            brick = GameObject.Find(player_name + "_Brick").GetComponent<UnityEngine.UI.Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}