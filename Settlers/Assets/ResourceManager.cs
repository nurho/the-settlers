using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The <c>ResourceManager</c> class is used for allocating resources to players
/// </summary>
public class ResourceManager : MonoBehaviour
{
    //TODO Potential major refactor of hex data structures to tile controllers

    // ----------------
    //    Variables
    // ----------------

    // Declare references to objects
    private Dictionary<string,  (List<GameObject>, string)> hexes;
    private List<GameObject> intersections;
    private List<List<GameObject>> hex_intersections;
    private PlayerController player;


    // ----------------
    //     Methods
    // ----------------

    /// <summary>
    /// Uses the given dice roll to allocate resources to intersections bordering the tile(s) with that number.
    /// </summary>
    /// <param name="roll_value">The value of the dice roll.</param>
    public void dice_allocation(int roll_value) {
        List<GameObject> adjacent_intersections = new List<GameObject>();

        switch (roll_value) {
            case 2:
                check_intersections("2");
                break;
            case 3:
                check_intersections("3_1");
                check_intersections("3_2");
                break;
            case 4:
                check_intersections("4_1");
                check_intersections("4_2");
                break;
            case 5:
                check_intersections("5_1");
                check_intersections("5_2");
                break;
            case 6:
                check_intersections("6_1");
                check_intersections("6_2");
                break;
            case 8:
                check_intersections("8_1");
                check_intersections("8_2");
                break;
            case 9:
                check_intersections("9_1");
                check_intersections("9_2");
                break;
            case 10:
                check_intersections("10_1");
                check_intersections("10_2");
                break;
            case 11:
                check_intersections("11_1");
                check_intersections("11_2");
                break;
            case 12:
                check_intersections("12");
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Checks the intersections of the specified hex for settlements/cities and allocates resources accordingly.
    /// </summary>
    /// <param name="hex">The name of the hex tile (it's token value and instance).</param>
    void check_intersections(string hex) {
        if (hex != Game.robber_location) {
            foreach (GameObject intersection in hexes[hex].Item1) {
                IntersectionController controller = intersection.GetComponent<IntersectionController>();
                if (controller.has_city) {
                    send_resource(controller.settlement_player, hexes[hex].Item2, 2);
                } else if (controller.has_settlement) {
                    send_resource(controller.settlement_player, hexes[hex].Item2, 1);
                }
            }
        } else {
            // TODO Add message?
            Debug.Log("Robber blocking" + hex);
        }
    }

    /// <summary>
    /// Sends an amount of a resource to a specified player.
    /// </summary>
    /// <param name="player_num">The number of the player to send to.</param>
    /// <param name="resource">The resource to allocate.</param>
    /// <param name="amount">The amount of the resource to send.</param>
    private void send_resource(int player_num, string resource, int amount) {
        if (player_num == 0) {
            player = GameObject.Find("Player_1").GetComponent<PlayerController>();
        } else if (player_num == 1) {
            player = GameObject.Find("Player_2").GetComponent<PlayerController>();
        } else if (player_num == 2) {
            player = GameObject.Find("Player_3").GetComponent<PlayerController>();
        } else if (player_num == 3) {
            player = GameObject.Find("Player_4").GetComponent<PlayerController>();
        }

        player.give_resource(resource, amount);
    }

    /// <summary>
    /// Special case of allocation used during the second turn of the game.
    /// </summary>
    /// <param name="intersection">The intersection the settlement was placed on.</param>
    /// <param name="player_turn">Which players turn it is.</param>
    public void turn_2_allocation(GameObject intersection, int player_turn) {
        Debug.Log("Allocate: " + intersection.name);
        if (player_turn == 0) {
            player = GameObject.Find("Player_1").GetComponent<PlayerController>();
        } else if (player_turn == 1) {
            player = GameObject.Find("Player_2").GetComponent<PlayerController>();
        } else if (player_turn == 2) {
            player = GameObject.Find("Player_3").GetComponent<PlayerController>();
        } else if (player_turn == 3) {
            player = GameObject.Find("Player_4").GetComponent<PlayerController>();
        }

        foreach (string key in hexes.Keys) {
            if (hexes[key].Item1.Contains(intersection)) {
                player.give_resource(hexes[key].Item2, 1);
            }
        }
    }

    /// <summary>
    /// Uses the layout of the board to assign a resource to each hex tile.
    /// </summary>
    public void setup_resources() {
        // Find objects
        List<string> tile_layout = Game.tile_layout;
        List<int> token_layout = Game.token_layout;

        // Setup intersection locations
        intersections = GameObject.Find("Intersections").GetComponent<IntersectionManager>().intersections;
        setup_intersections();

        // Convert tile type to resource type
        List<string> tile_resources = new List<string>();
        for (int i = 0; i < tile_layout.Count; i++) {
            if (tile_layout[i] == "mountain") {
                tile_resources.Add("ore");
            } else if (tile_layout[i] == "pasture") {
                tile_resources.Add("wool");
            } else if (tile_layout[i] == "hill") {
                tile_resources.Add("brick");
            } else if (tile_layout[i] == "field") {
                tile_resources.Add("grain");
            } else if (tile_layout[i] == "forest") {
                tile_resources.Add("lumber");
            } else {
                tile_resources.Add("desert");
            }
        }

        // Setup hex tiles with intersections and resource
        hexes = new Dictionary<string, (List<GameObject>, string)>();

        for (int i = 0; i < tile_resources.Count; i++) {
            switch (token_layout[i]) {
                case 0:
                    TileManager.tiles[i].GetComponent<TileController>().tile_token = "0";
                    break;
                case 2:
                    hexes.Add("2", (hex_intersections[i],tile_resources[i]));
                    TileManager.tiles[i].GetComponent<TileController>().tile_token = "2";
                    break;
                case 3:
                    if (!hexes.ContainsKey("3_1")) {
                        hexes.Add("3_1", (hex_intersections[i], tile_resources[i]));
                        TileManager.tiles[i].GetComponent<TileController>().tile_token = "3_1";
                    } else {
                        hexes.Add("3_2", (hex_intersections[i], tile_resources[i]));
                        TileManager.tiles[i].GetComponent<TileController>().tile_token = "3_2";
                    }
                    break;
                case 4:
                    if (!hexes.ContainsKey("4_1")) {
                        hexes.Add("4_1", (hex_intersections[i], tile_resources[i]));
                        TileManager.tiles[i].GetComponent<TileController>().tile_token = "4_1";
                    } else {
                        hexes.Add("4_2", (hex_intersections[i], tile_resources[i]));
                        TileManager.tiles[i].GetComponent<TileController>().tile_token = "4_2";
                    }
                    break;
                case 5:
                    if (!hexes.ContainsKey("5_1")) {
                        hexes.Add("5_1", (hex_intersections[i], tile_resources[i]));
                        TileManager.tiles[i].GetComponent<TileController>().tile_token = "5_1";
                    } else {
                        hexes.Add("5_2", (hex_intersections[i], tile_resources[i]));
                        TileManager.tiles[i].GetComponent<TileController>().tile_token = "5_2";
                    }
                    break;
                case 6:
                    if (!hexes.ContainsKey("6_1")) {
                        hexes.Add("6_1", (hex_intersections[i], tile_resources[i]));
                        TileManager.tiles[i].GetComponent<TileController>().tile_token = "6_1";
                    } else {
                        hexes.Add("6_2", (hex_intersections[i], tile_resources[i]));
                        TileManager.tiles[i].GetComponent<TileController>().tile_token = "6_2";
                    }
                    break;
                case 8:
                    if (!hexes.ContainsKey("8_1")) {
                        hexes.Add("8_1", (hex_intersections[i], tile_resources[i]));
                        TileManager.tiles[i].GetComponent<TileController>().tile_token = "8_1";
                    } else {
                        hexes.Add("8_2", (hex_intersections[i], tile_resources[i]));
                        TileManager.tiles[i].GetComponent<TileController>().tile_token = "8_2";
                    }
                    break;
                case 9:
                    if (!hexes.ContainsKey("9_1")) {
                        hexes.Add("9_1", (hex_intersections[i], tile_resources[i]));
                        TileManager.tiles[i].GetComponent<TileController>().tile_token = "9_1";
                    } else {
                        hexes.Add("9_2", (hex_intersections[i], tile_resources[i]));
                        TileManager.tiles[i].GetComponent<TileController>().tile_token = "9_2";
                    }
                    break;
                case 10:
                    if (!hexes.ContainsKey("10_1")) {
                        hexes.Add("10_1", (hex_intersections[i], tile_resources[i]));
                        TileManager.tiles[i].GetComponent<TileController>().tile_token = "10_1";
                    } else {
                        hexes.Add("10_2", (hex_intersections[i], tile_resources[i]));
                        TileManager.tiles[i].GetComponent<TileController>().tile_token = "10_2";
                    }
                    break;
                case 11:
                    if (!hexes.ContainsKey("11_1")) {
                        hexes.Add("11_1", (hex_intersections[i], tile_resources[i]));
                        TileManager.tiles[i].GetComponent<TileController>().tile_token = "11_1";
                    } else {
                        hexes.Add("11_2", (hex_intersections[i], tile_resources[i]));
                        TileManager.tiles[i].GetComponent<TileController>().tile_token = "11_2";
                    }
                    break;
                case 12:
                    hexes.Add("12", (hex_intersections[i], tile_resources[i]));
                    TileManager.tiles[i].GetComponent<TileController>().tile_token = "12";
                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// Assigns intersections to each hex tile.
    /// </summary>
    private void setup_intersections() {
        hex_intersections = new List<List<GameObject>>();
        hex_intersections.Add(new List<GameObject>() { intersections[0], intersections[1], intersections[2], intersections[8], intersections[9], intersections[10] });
        hex_intersections.Add(new List<GameObject>() { intersections[2], intersections[3], intersections[4], intersections[10], intersections[11], intersections[12] });
        hex_intersections.Add(new List<GameObject>() { intersections[4], intersections[5], intersections[6], intersections[12], intersections[13], intersections[14] });

        hex_intersections.Add(new List<GameObject>() { intersections[7], intersections[8], intersections[9], intersections[17], intersections[18], intersections[19] });
        hex_intersections.Add(new List<GameObject>() { intersections[9], intersections[10], intersections[11], intersections[19], intersections[20], intersections[21] });
        hex_intersections.Add(new List<GameObject>() { intersections[11], intersections[12], intersections[13], intersections[21], intersections[22], intersections[23] });
        hex_intersections.Add(new List<GameObject>() { intersections[13], intersections[14], intersections[15], intersections[23], intersections[24], intersections[25] });

        hex_intersections.Add(new List<GameObject>() { intersections[16], intersections[17], intersections[18], intersections[27], intersections[28], intersections[29] });
        hex_intersections.Add(new List<GameObject>() { intersections[18], intersections[19], intersections[20], intersections[29], intersections[30], intersections[31] });
        hex_intersections.Add(new List<GameObject>() { intersections[20], intersections[21], intersections[22], intersections[31], intersections[32], intersections[33] });
        hex_intersections.Add(new List<GameObject>() { intersections[22], intersections[23], intersections[24], intersections[33], intersections[34], intersections[35] });
        hex_intersections.Add(new List<GameObject>() { intersections[24], intersections[25], intersections[26], intersections[35], intersections[36], intersections[37] });

        hex_intersections.Add(new List<GameObject>() { intersections[28], intersections[29], intersections[30], intersections[38], intersections[39], intersections[40] });
        hex_intersections.Add(new List<GameObject>() { intersections[30], intersections[31], intersections[32], intersections[40], intersections[41], intersections[42] });
        hex_intersections.Add(new List<GameObject>() { intersections[32], intersections[33], intersections[34], intersections[42], intersections[43], intersections[44] });
        hex_intersections.Add(new List<GameObject>() { intersections[34], intersections[35], intersections[36], intersections[44], intersections[45], intersections[46] });

        hex_intersections.Add(new List<GameObject>() { intersections[39], intersections[40], intersections[41], intersections[47], intersections[48], intersections[49] });
        hex_intersections.Add(new List<GameObject>() { intersections[41], intersections[42], intersections[43], intersections[49], intersections[50], intersections[51] });
        hex_intersections.Add(new List<GameObject>() { intersections[43], intersections[44], intersections[45], intersections[51], intersections[52], intersections[53] });
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}