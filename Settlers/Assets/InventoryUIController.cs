using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIController : MonoBehaviour
{
    Image build_costs_image;
    Image lumber_image;
    Image brick_image;
    Image wool_image;
    Image grain_image;
    Image ore_image;
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
        build_costs_image = GameObject.Find("BuildCostsImage").GetComponent<Image>();
        lumber_image = GameObject.Find("Lumber").GetComponent<Image>();
        brick_image = GameObject.Find("Brick").GetComponent<Image>();
        wool_image = GameObject.Find("Wool").GetComponent<Image>();
        grain_image = GameObject.Find("Grain").GetComponent<Image>();
        ore_image= GameObject.Find("Ore").GetComponent<Image>();
        lumber_count = GameObject.Find("LumberCount").GetComponent<Text>();
        brick_count = GameObject.Find("BrickCount").GetComponent<Text>();
        wool_count = GameObject.Find("WoolCount").GetComponent<Text>();
        grain_count = GameObject.Find("GrainCount").GetComponent<Text>();
        ore_count = GameObject.Find("OreCount").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
         // Show the inventory when the space bar is held.
        if (Input.GetKeyDown(KeyCode.Space)) {
            refresh_UI();
            build_costs_image.enabled = true;
            lumber_image.enabled = true;
            brick_image.enabled = true;
            wool_image.enabled = true;
            grain_image.enabled = true;
            ore_image.enabled = true;
            lumber_count.enabled = true;
            brick_count.enabled = true;
            wool_count.enabled = true;
            grain_count.enabled = true;
            ore_count.enabled = true;
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            build_costs_image.enabled = false;
            lumber_image.enabled = false;
            brick_image.enabled = false;
            wool_image.enabled = false;
            grain_image.enabled = false;
            ore_image.enabled = false;
            lumber_count.enabled = false;
            brick_count.enabled = false;
            wool_count.enabled = false;
            grain_count.enabled = false;
            ore_count.enabled = false;

        }
    }
}