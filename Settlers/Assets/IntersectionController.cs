using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls information about an intersection and its settlement/city placement.
/// </summary>
public class IntersectionController : MonoBehaviour
{
    // ----------------
    //    Variables
    // ----------------

    // Settlement/city information.
    public bool has_settlement = false;
    public bool has_city = false;
    public int settlement_player;
    public bool has_neighbour = false;

    // Validity.
    bool valid_player_1 = true;
    bool valid_player_2 = true;
    bool valid_player_3 = true;
    bool valid_player_4 = true;

    // Containers for adjacent objects.
    public List<GameObject> adjacent_intersections = new List<GameObject>();
    public List<GameObject> adjacent_edges = new List<GameObject>();

    // Declare references to other objects/scripts (set in start method)
    SoundEffects sfx;
    Transform cross;


    // ----------------
    //     Methods
    // ----------------

    /// <summary>
    /// Add the adjacent intersections.
    /// </summary>
    /// <param name="intersections">List of adjacent intersection objects.</param>
    public void add_adjacent_intersections(List<GameObject> intersections) {
        foreach (GameObject intersection in intersections) {
            adjacent_intersections.Add(intersection);
        }
    }

    /// <summary>
    /// Add the adjacent edges.
    /// </summary>
    /// <param name="edges">List of adjacent edge objects.</param>
    public void add_adjacent_edges(List<GameObject> edges) {
        foreach (GameObject edge in edges) {
            adjacent_edges.Add(edge);
        }
    }

    /// <summary>
    /// Makes the intersection a valid settlement placement for a specific player.
    /// </summary>
    /// <param name="player_num">Player number.</param>
    public void valid_player(int player_num) {
        switch (player_num) {
            case 0:
                valid_player_1 = true;
                break;
            case 1:
                valid_player_2 = true;
                break;
            case 2:
                valid_player_3 = true;
                break;
            case 3:
                valid_player_4 = true;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Makes the intersection an invalid settlement placement for a specific player.
    /// </summary>
    /// <param name="player_num">Player number.</param>
    public void invalid_player(int player_num) {
        switch (player_num) {
            case 0:
                valid_player_1 = false;
                break;
            case 1:
                valid_player_2 = false;
                break;
            case 2:
                valid_player_3 = false;
                break;
            case 3:
                valid_player_4 = false;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Makes the intersection an invalid settlement placement for all players.
    /// </summary>
    public void invalid_all() {
        valid_player_1 = false;
        valid_player_2 = false;
        valid_player_3 = false;
        valid_player_4 = false;
    }

    /// <summary>
    /// Place the players settlement and set validities.
    /// </summary>
    /// <param name="player_num">Number of the player.</param>
    public void place_settlement(int player_num) {
        has_settlement = true;
        settlement_player = player_num;
        invalid_all();

        // Make adjacent intersections invalid to all.
        foreach (GameObject intersection in adjacent_intersections) {
            intersection.GetComponent<IntersectionController>().has_neighbour = true;
            intersection.GetComponent<IntersectionController>().invalid_all();
        }

        // Make adjacent edges valid for the players roads.
        foreach (GameObject edge in adjacent_edges) {
            edge.GetComponent<EdgeController>().valid_player(player_num);
        }
    }

    /// <summary>
    /// Upgrade the players settlement to a city.
    /// </summary>
    /// <param name="player_num">Number of the player.</param>
    public void place_city(int player_num) {
        has_city = true;
    }

    /// <summary>
    /// Moves a players settlement to this intersection to preview placement.
    /// </summary>
    /// <param name="player_name">Name of the player.</param>
    void select_settlement(string player_name) {
        sfx.select_sound();
        GameObject.Find(player_name).GetComponent<PlayerController>().current_settlement.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
        
        Game.current_intersection = this.gameObject;
        Game.valid_move = true;
    }

    /// <summary>
    /// Removes the intersection preview.
    /// </summary>
    /// <param name="player_name">Name of the player.</param>
    void deselect(string player_name) {
        GameObject player = GameObject.Find(player_name);
        if (Game.turn_state == Game.TurnStates.settlement) {
            player.GetComponent<PlayerController>().current_settlement.transform.position = player.transform.position;
            Game.valid_move = false;
            cross.position = new Vector2(-50, -50);
        } else if (Game.turn_state == Game.TurnStates.city) {
            player.GetComponent<PlayerController>().current_city.transform.position = player.transform.position;
            Game.valid_move = false;
            cross.position = new Vector2(-50, -50);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Find objects.
        sfx = GameObject.Find("SFX").GetComponent<SoundEffects>();
        cross = GameObject.Find("Cross").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter() {
        // Check validity and preview settlement/city placement.
        if (Game.turn_state == Game.TurnStates.settlement) {
            if (Game.player_turn == 0 && valid_player_1) {
                select_settlement("Player_1");
            } else if (Game.player_turn == 1 && valid_player_2) {
                select_settlement("Player_2");
            } else if (Game.player_turn == 2 && valid_player_3) {
                select_settlement("Player_3");
            } else if (Game.player_turn == 3 && valid_player_4) {
                select_settlement("Player_4");
            } else {
                sfx.invalid_sound();
                cross.position = new Vector2(this.transform.position.x, this.transform.position.y);
            }
        } else if (Game.turn_state == Game.TurnStates.city) {
            if ((Game.player_turn == settlement_player) && !has_city) {
                PlayerController playerc = null;
                if (Game.player_turn == 0) {
                    playerc = GameObject.Find("Player_1").GetComponent<PlayerController>();
                } else if (Game.player_turn == 1) {
                    playerc = GameObject.Find("Player_2").GetComponent<PlayerController>();
                } else if (Game.player_turn == 2) {
                    playerc = GameObject.Find("Player_3").GetComponent<PlayerController>();
                } else if (Game.player_turn == 3) {
                    playerc = GameObject.Find("Player_4").GetComponent<PlayerController>();
                }

                sfx.select_sound();
                playerc.current_city.transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
                Game.current_intersection = this.gameObject;
                Game.valid_move = true;
            } else {
                sfx.invalid_sound();
                cross.position = new Vector2(this.transform.position.x, this.transform.position.y);
            }
        }
    }

    private void OnMouseExit() {
        // Reset city/settlement selection preview.
        switch (Game.player_turn) {
            case 0:
                deselect("Player_1");
                break;
            case 1:
                deselect("Player_2");
                break;
            case 2:
                deselect("Player_3");
                break;
            case 3:
                deselect("Player_4");
                break;
        }
    }
}