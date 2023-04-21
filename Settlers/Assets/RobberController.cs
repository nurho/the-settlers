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

    // Set variables
    float text_display_time = 3f;


    // ----------------
    //     Methods
    // ----------------

    /// <summary>
    /// Triggers the robber turn state.
    /// </summary>
    public void trigger_robber() {
        Game.turn_state = Game.TurnStates.robber;
        StartCoroutine("show_robber_text");   
    }

    /// <summary>
    /// Displays the robber popup for a specified time.
    /// </summary>
    IEnumerator show_robber_text() {
        robber_text.enabled = true;
        yield return new WaitForSeconds(text_display_time);
        robber_text.enabled = false;
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