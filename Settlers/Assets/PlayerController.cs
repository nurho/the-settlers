using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Stores information about a player and controls their UI.
/// </summary>
public class PlayerController : MonoBehaviour
{
    // ----------------
    //    Variables
    // ----------------

    // Settlement variables.
    int free_settlements = 5;
    public GameObject current_settlement;
    List<GameObject> settlements;

    // City variables.
    int free_cities = 4;
    public GameObject current_city;
    List<GameObject> cities;

    // Road variables.
    int free_roads = 15;
    public GameObject current_road;
    List<GameObject> roads;

    // Scores.
    public int victory_points = 0;
    public int knight_count = 0;
    // TODO Upgrade to longest road (with method)
    public int roads_placed = 0;

    // Resources.
    public int lumber = 0;
    public int wool = 0;
    public int grain = 0;
    public int brick = 0;
    public int ore = 0;

    // Declare references to other objects/scripts (set in start method)
    PlayerUIController UI_controller;
    SoundEffects sfx;


    // ----------------
    //     Methods
    // ----------------

    /// <summary>
    /// Refreshes the values displayed in this players UI panel.
    /// </summary>
    public void refresh_UI() {
        UI_controller.update_values();
    }

    public string get_name() {
        char[] name = this.name.ToCharArray();
        name[6] = ' ';
        return new string(name);
    }   
    
    /// <summary>
    /// Confirms the placement of a settlement.
    /// </summary>
    public void place_settlement() {
        sfx.place_sound();
        free_settlements--;
        current_settlement = settlements[free_settlements - 1];
        victory_points++;
        refresh_UI();
        check_win();
    }

    /// <summary>
    /// Confirms the placement of a city.
    /// </summary>
    public void place_city() {
        sfx.place_sound();
        free_cities--;
        current_city = cities[free_cities - 1];
        victory_points++;
        refresh_UI();
        check_win();
    }

    /// <summary>
    /// Confirms the placement of a road.
    /// </summary>
    public void place_road() {
        sfx.place_sound();
        free_roads--;
        roads_placed++;
        current_road = roads[free_roads - 1];
        GameObject.Find("Game").GetComponent<Game>().check_longest_road(this);
    }

// TODO Document
    public int get_total_resources() {
        return lumber + brick + wool + grain + ore;
    }

    public string steal_random_resource() {
        List<string> resources = new List<string>();
        if (lumber > 0) {
            resources.Add("lumber");
        } else if (wool > 0) {
            resources.Add("wool");
        } else if (grain > 0) {
            resources.Add("grain");
        } else if (brick > 0) {
            resources.Add("brick");
        } else if (ore > 0) {
            resources.Add("ore");
        }

        string r = resources[Random.Range(0,resources.Count)];
        give_resource(r, -1);
        return r;
    }

    /// <summary>
    /// Gives the player a specified amount of the stated resource.
    /// </summary>
    /// <param name="resource"></param>
    /// <param name="amount"></param>
    public void give_resource (string resource, int amount) {
        switch (resource) {
            case "lumber":
                lumber += amount;
                break;
            case "wool":
                wool += amount;
                break;
            case "grain":
                grain += amount;
                break;
            case "brick":
                brick += amount;
                break;
            case "ore":
                ore += amount;
                break;
            default:
                break;
        }
        refresh_UI();
    }

    /// <summary>
    /// Gives the player a card of the specified type.
    /// </summary>
    /// <param name="card"></param>
    public void give_card(string card) {
        if (card == "victory") {
            Debug.Log(this.name + "recevies victory card");
            victory_points++;
            check_win();
        } else if (card == "knight") {
            knight_count++;
            GameObject.Find("Game").GetComponent<Game>().check_largest_army(this);
        }
        // TODO Add behaviour for other cards

        refresh_UI();
    }

    /// <summary>
    /// Triggers a win if the player has the required victory points.
    /// </summary>
    void check_win() {
        if (victory_points >= Game.points_to_win) {
            GameObject.Find("Game").GetComponent<Game>().trigger_win(this.name);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Find the players settlements.
        settlements = new List<GameObject>();
        foreach (Transform child in transform.GetChild(0).transform) {
            settlements.Add(child.gameObject);
        }
        current_settlement = settlements[0];

        // Find the players cities.
        cities = new List<GameObject>();
        foreach (Transform child in transform.GetChild(1).transform) {
            cities.Add(child.gameObject);
        }
        current_city = cities[0];

        // Find the players roads.
        roads = new List<GameObject>();
        foreach (Transform child in transform.GetChild(2).transform) {
            roads.Add(child.gameObject);
        }
        current_road = roads[0];

        // Find objects.
        UI_controller = this.gameObject.GetComponent<PlayerUIController>();
        sfx = GameObject.Find("SFX").GetComponent<SoundEffects>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}