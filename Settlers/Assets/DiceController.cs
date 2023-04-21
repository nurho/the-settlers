using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls the rolling of the dice and visual representation.
/// </summary>
public class DiceController : MonoBehaviour
{
    // ----------------
    //    Variables
    // ----------------

    readonly int bounces = 20;
    readonly float bounce_delay = .05f;
    int dice_1_value = 0;
    int dice_2_value = 0;

    // Set the sprites for the dice pips in editor and store them in a dictionary.
    public Sprite pips_1;
    public Sprite pips_2;
    public Sprite pips_3;
    public Sprite pips_4;
    public Sprite pips_5;
    public Sprite pips_6;
    Dictionary<int, Sprite> pip_sprites;

    // Declare references to other objects/scripts (set in start method)
    SpriteRenderer dice_1_renderer;
    SpriteRenderer dice_2_renderer;
    Button roll_dice_button;


    // ----------------
    //     Methods
    // ----------------

    /// <summary>
    /// Starts a dice roll.
    /// </summary>
    public void roll_dice() {
        roll_dice_button.enabled = false;
        GameObject.Find("SFX").GetComponent<SoundEffects>().roll_sound();
        StartCoroutine("rolling");   
    }

    /// <summary>
    /// Rolls the dice by randomising dice value for each bounce and processing the final result. Adds a delay between bounces.
    /// </summary>
    /// <returns></returns>
    IEnumerator rolling() {
        // Each cycle is one bounce.
        for (int i = 0; i < bounces; i++) {
            // Randomise the dice values.
            dice_1_value = Random.Range(1, 7);
            dice_2_value = Random.Range(1, 7);

            // Display the pips.
            dice_1_renderer.sprite = pip_sprites[dice_1_value];
            dice_2_renderer.sprite = pip_sprites[dice_2_value];

            yield return new WaitForSeconds(bounce_delay);
        }

        // After a final value is reached, process the result.
        if (dice_1_value + dice_2_value != 7) {
            GameObject.Find("Game").GetComponent<ResourceManager>().dice_allocation(dice_1_value + dice_2_value);
            Game.turn_state = Game.TurnStates.general;
        } else {
            GameObject.Find("Robber").GetComponent<RobberController>().trigger_robber();
        }
    }

    /// <summary>
    /// Enables the roll dice button.
    /// </summary>
    public void enable() {
        roll_dice_button.enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Find objects.
        dice_1_renderer = GameObject.Find("Dice_1_Pips").GetComponent<SpriteRenderer>();
        dice_2_renderer = GameObject.Find("Dice_2_Pips").GetComponent<SpriteRenderer>();
        roll_dice_button = GameObject.Find("RollDiceButton").GetComponent<Button>();

        // Create sprite dictionary.
        pip_sprites = new Dictionary<int, Sprite>() { { 1, pips_1 }, { 2, pips_2 }, { 3, pips_3 },
                                                      { 4, pips_4 }, { 5, pips_5 }, { 6, pips_6 } };
    }

    // Update is called once per frame
    void Update()
    {

    }
}