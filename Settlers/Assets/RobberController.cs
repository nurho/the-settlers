using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls the funcionality of the robber turn state and object.
/// </summary>
public class RobberController : MonoBehaviour
{
    // ----------------
    //    Variables
    // ----------------

    // Declare references to other objects/scripts (set in start method)
    GameObject robber;
    Image robber_text;
    GameObject discard_panel;
    InputField lumber_field;
    InputField brick_field;
    InputField wool_field;
    InputField grain_field;
    InputField ore_field;

    GameObject lumber_text;
    GameObject brick_text;
    GameObject wool_text;
    GameObject grain_text;
    GameObject ore_text;

    PlayerController current_player;

    // Set variables
    float text_display_time = 2f;
    bool resources_visible = false;
    int players_discarded = 0;


    // ----------------
    //     Methods
    // ----------------

    /// <summary>
    /// Triggers the robber turn state.
    /// </summary>
    public void trigger_robber() {
        StartCoroutine("show_robber_text");   
        Game.turn_state = Game.TurnStates.discarding;
    }

    /// <summary>
    /// Displays the robber popup for a specified time.
    /// </summary>
    IEnumerator show_robber_text() {
        robber_text.enabled = true;
        yield return new WaitForSeconds(text_display_time);
        robber_text.enabled = false;
        discard(Game.players[0]);
    }

    void discard(GameObject player) {
        current_player = player.GetComponent<PlayerController>();
        if (current_player.get_total_resources() > 7) {
            discard_panel.SetActive(true);
            Text discard_text = GameObject.Find("DiscardText").GetComponent<Text>();
            GameObject.Find("DiscardPlayerName").GetComponent<Text>().text = current_player.get_name();
            discard_text.text = "Discard " + Mathf.FloorToInt(current_player.get_total_resources() / 2) + " resources";
        } else {
            players_discarded++;
            if (players_discarded >= Game.num_players) {
                Game.turn_state = Game.TurnStates.robber;
                players_discarded = 0;
                discard_panel.SetActive(false);
            } else {
                discard(Game.players[players_discarded]);
            }
        }
    }

    public void discard_button() {
        int lumber;
        int brick;
        int wool;
        int grain;
        int ore;

        int.TryParse(lumber_field.text, out lumber);
        int.TryParse(brick_field.text, out brick);
        int.TryParse(wool_field.text, out wool);
        int.TryParse(grain_field.text, out grain);
        int.TryParse(ore_field.text, out ore);

        lumber_field.text = "";
        brick_field.text = "";
        wool_field.text = "";
        grain_field.text = "";
        ore_field.text = "";


        int total = lumber + brick + wool + grain + ore;
        if (total == Mathf.FloorToInt(current_player.get_total_resources() / 2) &&
                    current_player.lumber >= lumber &&
                    current_player.brick >= brick &&
                    current_player.wool >= wool &&
                    current_player.grain >= grain &&
                    current_player.ore >= ore) {
            current_player.give_resource("lumber", -lumber);
            current_player.give_resource("brick", -brick);
            current_player.give_resource("wool", -wool);
            current_player.give_resource("grain", -grain);
            current_player.give_resource("ore", -ore);
            players_discarded++;
            if (players_discarded >= Game.num_players) {
                Game.turn_state = Game.TurnStates.robber;
                players_discarded = 0;
                discard_panel.SetActive(false);
            } else {
                discard(Game.players[players_discarded]);
            }
        }
    }

    public void show_resources_button() {
        if (!resources_visible) {
            lumber_text.GetComponent<Text>().text = current_player.lumber.ToString();
            brick_text.GetComponent<Text>().text = current_player.brick.ToString();
            wool_text.GetComponent<Text>().text = current_player.wool.ToString();
            grain_text.GetComponent<Text>().text = current_player.grain.ToString();
            ore_text.GetComponent<Text>().text = current_player.ore.ToString();

            lumber_text.SetActive(true);
            brick_text.SetActive(true);
            wool_text.SetActive(true);
            grain_text.SetActive(true);
            ore_text.SetActive(true);

            GameObject.Find("ShowDiscardButtonText").GetComponent<Text>().text = "Hide Resources";
            resources_visible = true;
        } else {
            lumber_text.SetActive(false);
            brick_text.SetActive(false);
            wool_text.SetActive(false);
            grain_text.SetActive(false);
            ore_text.SetActive(false);
            GameObject.Find("ShowDiscardButtonText").GetComponent<Text>().text = "Show Resources";
            resources_visible = false;
        }
    }

    /// <summary>
    /// Sets the location of the robber logically and visually.
    /// </summary>
    public void place_robber() {
        Vector3 tile_pos = Game.current_tile.transform.position;
        GameObject.Find("SFX").GetComponent<SoundEffects>().place_sound();
        robber.transform.position = new Vector2(tile_pos.x + 0.2f, tile_pos.y - 0.2f);
    }

    // Start is called before the first frame update
    void Start()
    {
        // Find objects
        robber_text = GameObject.Find("RobberText").GetComponent<Image>();
        robber = GameObject.Find("Robber");
        discard_panel = GameObject.Find("DiscardPanel");
        lumber_field = GameObject.Find("LumberDiscardInputField").GetComponent<InputField>();
        brick_field = GameObject.Find("BrickDiscardInputField").GetComponent<InputField>();
        wool_field = GameObject.Find("WoolDiscardInputField").GetComponent<InputField>();
        grain_field = GameObject.Find("GrainDiscardInputField").GetComponent<InputField>();
        ore_field = GameObject.Find("OreDiscardInputField").GetComponent<InputField>();

        lumber_text = GameObject.Find("LumberDiscardText");
        brick_text = GameObject.Find("BrickDiscardText");
        wool_text = GameObject.Find("WoolDiscardText");
        grain_text = GameObject.Find("GrainDiscardText");
        ore_text = GameObject.Find("OreDiscardText");

        lumber_text.SetActive(false);
        brick_text.SetActive(false);
        wool_text.SetActive(false);
        grain_text.SetActive(false);
        ore_text.SetActive(false);


        discard_panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Bind the robber object to the cursor when in the robber turn state
        if (Game.turn_state == Game.TurnStates.robber) {
            robber.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        }
    }
}