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
    PlayerController current_player;

    // Set variables
    float text_display_time = 2f;
    bool valid_discard = false;


    // ----------------
    //     Methods
    // ----------------

    /// <summary>
    /// Triggers the robber turn state.
    /// </summary>
    public void trigger_robber() {
        StartCoroutine("show_robber_text");   
        Game.turn_state = Game.TurnStates.robber;
    }

    /// <summary>
    /// Displays the robber popup for a specified time.
    /// </summary>
    IEnumerator show_robber_text() {
        robber_text.enabled = true;
        yield return new WaitForSeconds(text_display_time);
        robber_text.enabled = false;
    }

    void discard() {

        for (int i = 0; i < Game.num_players; i++) {
            current_player = Game.players[i].GetComponent<PlayerController>();
            if (current_player.get_total_resources() > 7) {


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

        int total = lumber + brick + wool + grain + ore;
        if (total == Mathf.FloorToInt(current_player.get_total_resources() / 2)) {
            current_player.give_resource("lumber", -lumber);
            current_player.give_resource("brick", -brick);
            current_player.give_resource("wool", -wool);
            current_player.give_resource("grain", -grain);
            current_player.give_resource("ore", -ore);

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
        lumber_field = GameObject.Find("LumberDiscardInputField");
        brick_field = GameObject.Find("BrickDiscardInputField");
        wool_field = GameObject.Find("WoolDiscardInputField");
        grain_field = GameObject.Find("GrainDiscardInputField");
        ore_field = GameObject.Find("OreDiscardInputField");

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