using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls information about an edge and its road placement.
/// </summary>
public class EdgeController : MonoBehaviour
{
    // ----------------
    //    Variables
    // ----------------

    // Road information.
    public bool has_road = false;
    public int road_player;

    // Validity.
    bool valid_player_1 = false;
    bool valid_player_2 = false;
    bool valid_player_3 = false;
    bool valid_player_4 = false;

    // Positional information.
    readonly Dictionary<string, float> orientations = new Dictionary<string, float>() { { "left_up", 60f },
                                                                                        { "left_down", -60f },
                                                                                        { "vertical", 0f } };
    string orientation;
    Transform current_road_transform;

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
    /// Set the edge position and orientation for roads.
    /// </summary>
    /// <param name="edge_position"></param>
    /// <param name="edge_orientation"></param>
    public void setup_edge(Vector3 edge_position, string edge_orientation) {
        transform.position = edge_position;
        orientation = edge_orientation;
    }

    /// <summary>
    /// Adds an intersection to the list of adjacents.
    /// </summary>
    /// <param name="intersection"></param>
    public void add_adjacent_intersection(GameObject intersection) {
        adjacent_intersections.Add(intersection);
    }

    /// <summary>
    /// Add the adjacent edges.
    /// </summary>
    /// <param name="edges"></param>
    public void add_adjacents(List<GameObject> edges) {
        foreach (GameObject edge in edges) {
            adjacent_edges.Add(edge);
        }
    }

    /// <summary>
    /// Makes the edge a valid road placement for a specific player.
    /// </summary>
    /// <param name="player_num"></param>
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
    /// Makes the edge an invalid road placement for a specific player.
    /// </summary>
    /// <param name="player_num"></param>
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
    /// Makes the edge an invalid road placement for all players.
    /// </summary>
    public void invalid_all() {
        valid_player_1 = false;
        valid_player_2 = false;
        valid_player_3 = false;
        valid_player_4 = false;
    }

    /// <summary>
    /// Place the players road and set validities.
    /// </summary>
    /// <param name="player_num">Number of the player.</param>
    public void place_road(int player_num) {
        has_road = true;
        road_player = player_num;
        invalid_all();

        // Make intersections adjacent to road valid for players settlements
        foreach (GameObject intersection in adjacent_intersections) {
            IntersectionController controller = intersection.GetComponent<IntersectionController>();
            if (!controller.has_settlement && !controller.has_neighbour) {
                controller.valid_player(player_num);
            }
        }

        // Make edges adjacent to road valid for players roads
        foreach (GameObject edge in adjacent_edges) {
            EdgeController controller = edge.GetComponent<EdgeController>();
            if (!controller.has_road) {
                controller.valid_player(player_num);
            }
        }
    }

    /// <summary>
    /// Moves a players road to this edge to preview placement.
    /// </summary>
    /// <param name="player_name"></param>
    void select(string player_name) {
        sfx.select_sound();
        current_road_transform = GameObject.Find(player_name).GetComponent<PlayerController>().current_road.transform;
        current_road_transform.position = new Vector2(this.transform.position.x, this.transform.position.y);
        current_road_transform.rotation = Quaternion.Euler(0f, 0f, orientations[orientation]);

        Game.current_edge = this.gameObject;
        Game.valid_move = true;
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
        // Check validity and preview road placement.
        if(Game.turn_state == Game.TurnStates.road) {
            if (Game.player_turn == 0 && valid_player_1) {
                select("Player_1");
            } else if (Game.player_turn == 1 && valid_player_2) {
                select("Player_2");
            } else if (Game.player_turn == 2 && valid_player_3) {
                select("Player_3");
            } else if (Game.player_turn == 3 && valid_player_4) {
                select("Player_4");
            } else {
                sfx.invalid_sound();
                cross.position = new Vector2(this.transform.position.x, this.transform.position.y);
            }
        }
    }

    private void OnMouseExit() {
        // Reset road placement preview.
        if (Game.turn_state == Game.TurnStates.road) {
            GameObject player;
            switch (Game.player_turn) {
                case 0:
                    player = GameObject.Find("Player_1");
                    break;
                case 1:
                    player = GameObject.Find("Player_2");
                    break;
                case 2:
                    player = GameObject.Find("Player_3");
                    break;
                case 3:
                    player = GameObject.Find("Player_4");
                    break;
                default:
                    player = null;
                    break;
            }

            player.GetComponent<PlayerController>().current_road.transform.position = player.transform.position;
            Game.valid_move = false;
            cross.position = new Vector2(-50, -50);
        }
    }
}