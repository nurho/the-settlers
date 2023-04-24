using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIController : MonoBehaviour
{
    GameObject inventory_panel;
    Text lumber_count;
    Text brick_count;
    Text wool_count;
    Text grain_count;
    Text ore_count;
    PlayerController current_player;
    
    // TODO Document
    void refresh_UI() {
        current_player = Game.get_current_player().GetComponent<PlayerController>();
        lumber_count.text = current_player.lumber.ToString();
        brick_count.text = current_player.brick.ToString();
        wool_count.text = current_player.wool.ToString();
        grain_count.text = current_player.grain.ToString();
        ore_count.text = current_player.ore.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Find the inventory panel
        inventory_panel = GameObject.Find("InventoryPanel");

        // Find all the text objects
        lumber_count = GameObject.Find("LumberCount").GetComponent<Text>();
        brick_count = GameObject.Find("BrickCount").GetComponent<Text>();
        wool_count = GameObject.Find("WoolCount").GetComponent<Text>();
        grain_count = GameObject.Find("GrainCount").GetComponent<Text>();
        ore_count = GameObject.Find("OreCount").GetComponent<Text>();

        // Initially disable the inventory panel
        inventory_panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Game.turn_state == Game.TurnStates.general) {
            // Show the inventory when the space bar is held.
            if (Input.GetKeyDown(KeyCode.Space)) {
                inventory_panel.SetActive(true);
                refresh_UI();
            }

            if (Input.GetKeyUp(KeyCode.Space)) {
                inventory_panel.SetActive(false);
            }
        }
    }
}