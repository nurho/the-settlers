using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TradeController : MonoBehaviour
{
    GameObject trading_panel;
    InputField lumber_give_field;
    InputField brick_give_field;
    InputField wool_give_field;
    InputField grain_give_field;
    InputField ore_give_field;

    InputField lumber_receive_field;
    InputField brick_receive_field;
    InputField wool_receive_field;
    InputField grain_receive_field;
    InputField ore_receive_field;
    
    PlayerController current_player;

    public void trade_button() {
        if (Game.turn_state == Game.TurnStates.general) {
            current_player = Game.get_current_player().GetComponent<PlayerController>();
            Game.turn_state = Game.TurnStates.trading;
            trading_panel.SetActive(true);
        }
    }

    public void bank_trade_button() {
        int num_to_receive = 0;
        int num_requested = 0;
        bool valid_trade = true;

        int give_lumber;
        int give_brick;
        int give_wool;
        int give_grain;
        int give_ore;

        int.TryParse(lumber_give_field.text, out give_lumber);
        int.TryParse(brick_give_field.text, out give_brick);
        int.TryParse(wool_give_field.text, out give_wool);
        int.TryParse(grain_give_field.text, out give_grain);
        int.TryParse(ore_give_field.text, out give_ore);

        int receive_lumber;
        int receive_brick;
        int receive_wool;
        int receive_grain;
        int receive_ore;

        int.TryParse(lumber_receive_field.text, out receive_lumber);
        int.TryParse(brick_receive_field.text, out receive_brick);
        int.TryParse(wool_receive_field.text, out receive_wool);
        int.TryParse(grain_receive_field.text, out receive_grain);
        int.TryParse(ore_receive_field.text, out receive_ore);

        num_to_receive += Mathf.FloorToInt(give_lumber / 4);
        num_to_receive += Mathf.FloorToInt(give_brick / 4);
        num_to_receive += Mathf.FloorToInt(give_wool / 4);
        num_to_receive += Mathf.FloorToInt(give_grain / 4);
        num_to_receive += Mathf.FloorToInt(give_ore / 4);

        num_requested += receive_lumber;
        num_requested += receive_brick;
        num_requested += receive_wool;
        num_requested += receive_grain;
        num_requested += receive_ore;

        if (num_requested != num_to_receive) {
            Debug.Log("Invalid trade");
            valid_trade = false;
        }

        // TODO Add check for leftover gives when harbours are done

        if (    current_player.lumber < give_lumber ||
                current_player.brick < give_brick ||
                current_player.wool < give_wool ||
                current_player.grain < give_grain ||
                current_player.ore < give_ore) {
            Debug.Log("Not enough resources");
            valid_trade = false;
        }

        if (valid_trade) {
            current_player.give_resource("lumber", -(Mathf.FloorToInt(give_lumber / 4) * 4));
            current_player.give_resource("brick", -(Mathf.FloorToInt(give_brick / 4) * 4));
            current_player.give_resource("wool", -(Mathf.FloorToInt(give_wool / 4) * 4));
            current_player.give_resource("grain", -(Mathf.FloorToInt(give_grain / 4) * 4));
            current_player.give_resource("ore", -(Mathf.FloorToInt(give_ore / 4) * 4));

            current_player.give_resource("lumber", receive_lumber);
            current_player.give_resource("brick", receive_brick);
            current_player.give_resource("wool", receive_wool);
            current_player.give_resource("grain", receive_grain);
            current_player.give_resource("ore", receive_ore);
        }

        reset_fields();
        Game.turn_state = Game.TurnStates.general;
        trading_panel.SetActive(false);
    }

    public void player_trade_button() {
        reset_fields();
        Game.turn_state = Game.TurnStates.general;
        trading_panel.SetActive(false);
    }

    public void cancel_trade_button() {
        reset_fields();
        Game.turn_state = Game.TurnStates.general;
        trading_panel.SetActive(false);
    }

    void reset_fields() {
        lumber_give_field.text = "";
        brick_give_field.text = "";
        wool_give_field.text = "";
        grain_give_field.text = "";
        ore_give_field.text = "";

        lumber_receive_field.text = "";
        brick_receive_field.text = "";
        wool_receive_field.text = "";
        grain_receive_field.text = "";
        ore_receive_field.text = "";
    }

    // Start is called before the first frame update
    void Start()
    {
        trading_panel = GameObject.Find("TradePanel");
        lumber_give_field = GameObject.Find("LumberGiveInputField").GetComponent<InputField>();
        brick_give_field = GameObject.Find("BrickGiveInputField").GetComponent<InputField>();
        wool_give_field = GameObject.Find("WoolGiveInputField").GetComponent<InputField>();
        grain_give_field = GameObject.Find("GrainGiveInputField").GetComponent<InputField>();
        ore_give_field = GameObject.Find("OreGiveInputField").GetComponent<InputField>();

        lumber_receive_field = GameObject.Find("LumberReceiveInputField").GetComponent<InputField>();
        brick_receive_field = GameObject.Find("BrickReceiveInputField").GetComponent<InputField>();
        wool_receive_field = GameObject.Find("WoolReceiveInputField").GetComponent<InputField>();
        grain_receive_field = GameObject.Find("GrainReceiveInputField").GetComponent<InputField>();
        ore_receive_field = GameObject.Find("OreReceiveInputField").GetComponent<InputField>();

        trading_panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
