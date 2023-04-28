using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIController : MonoBehaviour
{
    public GameObject DevCard;

    GameObject inventory_panel;
    Text lumber_count;
    Text brick_count;
    Text wool_count;
    Text grain_count;
    Text ore_count;
    Text victory_points;
    PlayerController current_player;

    List<GameObject> current_cards = new List<GameObject>();

    // TODO Document
    void refresh_UI() {
        current_player = Game.get_current_player().GetComponent<PlayerController>();
        lumber_count.text = current_player.lumber.ToString();
        brick_count.text = current_player.brick.ToString();
        wool_count.text = current_player.wool.ToString();
        grain_count.text = current_player.grain.ToString();
        ore_count.text = current_player.ore.ToString();
        victory_points.text = current_player.victory_points.ToString();
    }

    void create_dev_cards() {
        GameObject content = GameObject.Find("DevCardContent");
        foreach (string card_name in current_player.dev_cards) {
            GameObject card = Instantiate(DevCard);
            card.GetComponent<DevCardController>().setup(card_name);
            card.transform.SetParent(content.transform, false);
            current_cards.Add(card);
        }
    }

    private void destroy_dev_cards() {
        foreach (GameObject card in current_cards) {
            Destroy(card);
        }
    }

    public void open_inventory() {
        inventory_panel.SetActive(true);
        refresh_UI();
        create_dev_cards();
    }
    
    public void close_inventory() {
        destroy_dev_cards();
        inventory_panel.SetActive(false);
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
        victory_points = GameObject.Find("VPText").GetComponent<Text>();

        // Initially disable the inventory panel
        inventory_panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Game.turn_state == Game.TurnStates.general) {
            // Show the inventory when the space bar is pressed.
            if (Input.GetKeyDown(KeyCode.Space)) {
                open_inventory();
                Game.turn_state = Game.TurnStates.inventory;
            }
        } else if (Game.turn_state == Game.TurnStates.inventory) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                close_inventory();
                Game.turn_state = Game.TurnStates.general;
            }
        }
    }
}