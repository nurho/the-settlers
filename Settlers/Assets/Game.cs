using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices.ComTypes;

/// <summary>
/// Contains the main logic for the overall state and game loop.
/// </summary>
public class Game : MonoBehaviour {
    // ----------------
    //    Types
    // ----------------

    // Enum type for major game states
    public enum GameStates {
        first_turn,
        second_turn,
        general
    }

    // Enum type for states in a turn
    public enum TurnStates {
        diceroll,
        general,
        settlement,
        city,
        road,
        trading,
        discarding,
        robber,
        stealing
    }


    // ----------------
    //     VARIABLES
    // ----------------

    // Set game options
    // TODO Have these selected in pre game menu
    public static int points_to_win = 5;
    public static int num_players = 3;
    public static string layout_mode = "basic";

    // Declare references to other objects/scripts (set in start method)
    public static List<GameObject> players;
    PlayerController longest_road_player;
    PlayerController largest_army_player;
    ResourceManager resource_manager;
    TurnIndicator turn_indicator;

    // Set variables
    public static GameStates game_state = GameStates.first_turn;
    public static TurnStates turn_state = TurnStates.settlement;
    public static int player_turn = 0;
    public static string robber_location = "0";
    public static bool valid_move = false;
    public bool dice_enabled = false;
    public static List<string> tile_layout;
    public static List<int> token_layout;
    public static GameObject current_intersection;
    public static GameObject current_edge;
    public static GameObject current_tile;

    // Basic (beginner) layouts
    public List<string> basic_tile_layout = new List<string> { "mountain", "pasture", "forest",
                                        "field", "hill", "pasture", "hill",
                                        "field", "forest", "desert", "forest", "mountain",
                                        "forest", "mountain", "field", "pasture",
                                        "hill", "field", "pasture" };

    public List<int> basic_token_layout = new List<int> { 10, 2, 9,
                                        12, 6, 4, 10,
                                        9, 11, 0, 3, 8,
                                        8, 3, 4, 5,
                                        5, 6, 11 };


    // ----------------
    //    Methods
    // ----------------

    // TODO Document
    public static GameObject get_current_player() {
        return players[player_turn];
    }

    private List<string> create_random_tile_layout() {
        int i;
        List<string> temp_layout = new List<string>();
        foreach (string tile in basic_tile_layout) {
            i = Random.Range(0, 2);
            Debug.Log("Tile random: " + i);
            if (i == 0) {
                temp_layout.Add(tile);
            } else if (i == 1) {
                temp_layout.Insert(0, tile);
            }
        }

        return temp_layout;
    }

    private List<int> create_random_token_layout(List<string> tiles) {
        List<int> numbers = new List<int> { 2, 3, 3, 4, 4, 5, 5, 6, 6, 8, 8, 9, 9, 10, 10, 11, 11, 12 };
        List<int> temp_layout = new List<int>();

        int i;
        foreach (int token in numbers) {
            i = Random.Range(0, 2);
            if (i == 0) {
                temp_layout.Add(token);
            } else if (i == 1) {
                temp_layout.Insert(0, token);
            }
        }

        for (i = 0; i < tiles.Count; i++) {
            if (tiles[i] == "desert") {
                temp_layout.Insert(i, 0);
            }
        }

        return temp_layout;
    }

    /// <summary>
    /// Ends the current players turn. 
    /// Called in editor by "EndTurnButton".
    /// </summary>
    public void next_turn() {
        if (turn_state == TurnStates.general) {
            player_turn++;
            turn_indicator.set_indicator(player_turn);
            turn_state = TurnStates.diceroll;
            dice_enabled = false;
            if (player_turn == num_players) {
                player_turn = 0;
                turn_indicator.set_indicator(player_turn);
            }
        }
    }

    /// <summary>
    /// Enters the settlement building state if the current player has the required resources.
    /// Called in editor by "BuildSettlementButton".
    /// </summary>
    public void build_settlement() {
        PlayerController playerc = players[player_turn].GetComponent<PlayerController>();
        if (turn_state == TurnStates.general) {
            if ((playerc.lumber > 0) && (playerc.brick > 0) && (playerc.wool > 0) && (playerc.grain > 0)) {
                playerc.lumber--;
                playerc.brick--;
                playerc.wool--;
                playerc.grain--;
                playerc.refresh_UI();
                turn_state = TurnStates.settlement;
            } else {
                Debug.Log("Not enough resources");
            }
        } else if (turn_state == TurnStates.settlement) {
            playerc.lumber++;
            playerc.brick++;
            playerc.wool++;
            playerc.grain++;
            playerc.refresh_UI();
            turn_state = TurnStates.general;
        }
    }

    /// <summary>
    /// Enters the city building state if the current player has the required resources.
    /// Called in editor by "BuildCityButton".
    /// </summary>
    public void build_city() {
        PlayerController playerc = players[player_turn].GetComponent<PlayerController>();
        if (turn_state == TurnStates.general) {
            if ((playerc.ore >= 3) && (playerc.grain >= 2)) {
                playerc.ore -= 3;
                playerc.grain -= 2;
                playerc.refresh_UI();
                turn_state = TurnStates.city;
            } else {
                Debug.Log("Not enough resources");
            }
        } else if (turn_state == TurnStates.city) {
            playerc.ore += 3;
            playerc.grain += 2;
            playerc.refresh_UI();
            turn_state = TurnStates.general;
        }
    }

    /// <summary>
    /// Enters the road building state if the current player has the required resources.
    /// Called in editor by "BuildRoadButton".
    /// </summary>
    public void build_road() {
        PlayerController playerc = players[player_turn].GetComponent<PlayerController>();
        if (turn_state == TurnStates.general) {
            if ((playerc.lumber > 0) && (playerc.brick > 0)) {
                playerc.lumber--;
                playerc.brick--;
                playerc.refresh_UI();
                turn_state = TurnStates.road;
            } else {
                Debug.Log("Not enough resources");
            }
        } else if (turn_state == TurnStates.road) {
            playerc.lumber++;
            playerc.brick++;
            playerc.refresh_UI();
            turn_state = TurnStates.general;
        }
    }

    /// <summary>
    /// Creates and issues a development card if the current player has the required resources.
    /// Called in editor by "BuildCardButton".
    /// </summary>
    public void build_card() {
        if (turn_state == TurnStates.general) {
            PlayerController playerc = players[player_turn].GetComponent<PlayerController>();
            if ((playerc.wool > 0) && (playerc.grain > 0) && (playerc.ore > 0)) {
                playerc.wool--;
                playerc.grain--;
                playerc.ore--;
                playerc.refresh_UI();
                playerc.give_card(GameObject.Find("DevCardDeck").GetComponent<DevCardDeck>().draw_card());
            } else {
                Debug.Log("Not enough resources");
            }
        }
    }

    /// <summary>
    /// Triggers a game win for the specified player.
    /// </summary>
    /// <param name="player_name">Name of the victorious player.</param>
    public void trigger_win(string player_name) {
        StartCoroutine("show_win_text", player_name);
    }

    /// <summary>
    /// This coroutine is used by the <c>trigger_win</c> method to display a message and reset the game after a delay.
    /// </summary>
    /// <param name="player_name">Name of the victorious player.</param>
    /// <returns></returns>
    IEnumerator show_win_text(string player_name) {
        Text win_text = GameObject.Find("WinText").GetComponent<Text>();
        win_text.text = player_name + "wins!";
        win_text.enabled = true;
        yield return new WaitForSeconds(8f);
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Check if the specified player should be awarded longest road.
    /// </summary>
    /// <param name="player">The <c>PlayerController</c> of the player to check.</param>
    public void check_longest_road(PlayerController player) {
        // TODO Make better
        if (longest_road_player) {
            if (player.roads_placed > longest_road_player.roads_placed && player != longest_road_player) {
                longest_road_player.victory_points -= 2;
                longest_road_player.refresh_UI();
                player.victory_points += 2;
                player.refresh_UI();
                longest_road_player = player;
            }
        } else {
            if (player.roads_placed >= 5) {
                player.victory_points += 2;
                longest_road_player = player;
                player.refresh_UI();
            }
        }
    }

    /// <summary>
    /// Check if the specified player should be awarded largest army.
    /// </summary>
    /// <param name="player">The <c>PlayerController</c> of the player to check.</param>
    public void check_largest_army(PlayerController player) {
        if (largest_army_player) {
            if (player.knight_count > largest_army_player.knight_count && player != largest_army_player) {
                largest_army_player.victory_points -= 2;
                largest_army_player.refresh_UI();
                player.victory_points += 2;
                player.refresh_UI();
                largest_army_player = player;
            }
        } else {
            if (player.knight_count >= 3) {
                player.victory_points += 2;
                largest_army_player = player;
                player.refresh_UI();
            }
        }
    }


    // Start is called before the first frame update
    void Start() {
        // Set the basic layout or create a random one
        if (layout_mode == "basic") {
            tile_layout = basic_tile_layout;
            token_layout = basic_token_layout;
        } else if (layout_mode == "random") {
            // TODO Create a function for random layouts i.e. advanced rules (eventually also custom layouts)
            tile_layout = create_random_tile_layout();
            token_layout = create_random_token_layout(tile_layout);
        }

        // Setup game board (tiles and tokens)
        GameObject board = GameObject.Find("Board");
        board.GetComponent<TileManager>().setup_tiles();
        board.GetComponent<TileManager>().place_tiles(tile_layout);
        board.GetComponent<TokenManager>().setup_tokens();
        board.GetComponent<TokenManager>().place_tokens(token_layout);
        GameObject.Find("Intersections").GetComponent<IntersectionManager>().setup_intersections();
        board.GetComponent<TileManager>().set_adjacent_intersections();

        //GameObject.Find("Board").transform.position = new Vector2(map_offset_x, map_offset_y);
        //GameObject.Find("Main Camera").transform.position = new Vector3(0.8660254f, (3 * 0.75f), -10);
        //GameObject.Find("Main Camera").transform.position = new Vector3(BoardData.tile_positions[10,0], BoardData.tile_positions[10,1], -10);
        GameObject.Find("Main Camera").transform.position = new Vector3(0.8660254f, 2, -10);

        // Find and add players
        players = new List<GameObject>() { GameObject.Find("Player_1"), GameObject.Find("Player_2"), GameObject.Find("Player_3") };
        if (num_players == 4) {
            players.Add(GameObject.Find("Player_4"));
        } else {
            GameObject.Find("Panel_Player_4").SetActive(false);
        }

        // Find other objects
        resource_manager = this.GetComponent<ResourceManager>();
        turn_indicator = GameObject.Find("TurnIndicator").GetComponent<TurnIndicator>();
    }

    // Update is called once per frame
    void Update()
    {
        // First turn state loop
        if (game_state == GameStates.first_turn) {
            if (Input.GetMouseButtonDown(0)) {
                if ((turn_state == TurnStates.settlement) && valid_move) {
                    players[player_turn].GetComponent<PlayerController>().place_settlement();
                    current_intersection.GetComponent<IntersectionController>().place_settlement(player_turn);

                    turn_state = TurnStates.road;
                    valid_move = false;
                } else if (turn_state == TurnStates.road && valid_move) {
                    players[player_turn].GetComponent<PlayerController>().place_road();
                    current_edge.GetComponent<EdgeController>().place_road(player_turn);

                    turn_state = TurnStates.settlement;
                    player_turn++;
                    turn_indicator.set_indicator(player_turn);

                    // When all players have taken their first turn, enter second turn state
                    if (player_turn == num_players) {
                        player_turn--;
                        turn_indicator.set_indicator(player_turn);
                        game_state = GameStates.second_turn;
                    }
                }
            }
        // Second turn state loop
        } else if (game_state == GameStates.second_turn) {
            if (Input.GetMouseButtonDown(0)) {
                if ((turn_state == TurnStates.settlement) && valid_move) {
                    players[player_turn].GetComponent<PlayerController>().place_settlement();
                    current_intersection.GetComponent<IntersectionController>().place_settlement(player_turn);
                    resource_manager.turn_2_allocation(current_intersection, player_turn);

                    turn_state = TurnStates.road;
                    valid_move = false;
                } else if (turn_state == TurnStates.road && valid_move) {
                    players[player_turn].GetComponent<PlayerController>().place_road();
                    current_edge.GetComponent<EdgeController>().place_road(player_turn);

                    turn_state = TurnStates.settlement;
                    player_turn--;
                    turn_indicator.set_indicator(player_turn);

                    // When all players have taken their second turn, refresh intersection validity and enter general game state
                    if (player_turn < 0) {
                        player_turn = 0;
                        turn_indicator.set_indicator(player_turn);
                        game_state = GameStates.general;
                        turn_state = TurnStates.diceroll;
                        
                        GameObject.Find("Intersections").GetComponent<IntersectionManager>().refresh_validity();

                        // TODO Collapse the following into a single statement that activates the entire build panel
                        GameObject.Find("BuildSettlementButton").GetComponent<Button>().enabled = true;
                        GameObject.Find("BuildCityButton").GetComponent<Button>().enabled = true;
                        GameObject.Find("BuildRoadButton").GetComponent<Button>().enabled = true;
                        GameObject.Find("BuildCardButton").GetComponent<Button>().enabled = true;
                    }
                }
            }
        // General state loop for the rest of the game
        } else if (game_state == GameStates.general) {
            // Behaviours for the various turn states
            if (turn_state == TurnStates.diceroll) {
                if (!dice_enabled) {
                    GameObject.Find("Dice").GetComponent<DiceController>().enable();
                    dice_enabled = true;
                }
            } else if (turn_state == TurnStates.settlement) {
                if (Input.GetMouseButtonDown(0)) {
                    if ((turn_state == TurnStates.settlement) && valid_move) {
                        players[player_turn].GetComponent<PlayerController>().place_settlement();
                        current_intersection.GetComponent<IntersectionController>().place_settlement(player_turn);

                        turn_state = TurnStates.general;
                        valid_move = false;
                    }
                }
            } else if (turn_state == TurnStates.city) {
                if (Input.GetMouseButtonDown(0)) {
                    if ((turn_state == TurnStates.city) && valid_move) {
                        players[player_turn].GetComponent<PlayerController>().place_city();
                        current_intersection.GetComponent<IntersectionController>().place_city(player_turn);

                        turn_state = TurnStates.general;
                        valid_move = false;
                    }
                }
            } else if (turn_state == TurnStates.road) {
                if (Input.GetMouseButtonDown(0)) {
                    if ((turn_state == TurnStates.road) && valid_move) {
                        players[player_turn].GetComponent<PlayerController>().place_road();
                        current_edge.GetComponent<EdgeController>().place_road(player_turn);

                        turn_state = TurnStates.general;
                        valid_move = false;
                    }
                }
            } else if (turn_state == TurnStates.robber) {
                if (Input.GetMouseButtonDown(0) && valid_move) {
                    valid_move = false;
                    RobberController robber = GameObject.Find("Robber").GetComponent<RobberController>();
                    robber_location = current_tile.GetComponent<TileController>().tile_token;
                    robber.place_robber();
                    turn_state = TurnStates.stealing;
                    robber.steal(current_tile);
                }
            }
        }
    }
}