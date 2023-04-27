using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DevCardController : MonoBehaviour
{
    public Sprite Knight;

    public Sprite chapel;
    public Sprite library;
    public Sprite market;
    public Sprite palace;
    public Sprite university;

    public Sprite monopoly;
    public Sprite road_building;
    public Sprite year_of_plenty;

    public string type;
    Button button;

    public void setup(string t) {
        type = t;
        Debug.Log("card setup");

        switch (type) {
            case "knight":
                gameObject.GetComponent<Image>().sprite = Knight; break;
            case "chapel":
                gameObject.GetComponent<Image>().sprite = chapel; break;
            case "library":
                gameObject.GetComponent<Image>().sprite = library; break;
            case "market":
                gameObject.GetComponent<Image>().sprite = market; break;
            case "palace":
                gameObject.GetComponent<Image>().sprite = palace; break;
            case "university":
                gameObject.GetComponent<Image>().sprite = university; break;
            case "monopoly":
                gameObject.GetComponent<Image>().sprite = monopoly; break;
            case "road_building":
                gameObject.GetComponent<Image>().sprite = road_building; break;
            case "year_of_plenty":
                gameObject.GetComponent<Image>().sprite = year_of_plenty; break;

        }

        
        Debug.Log("type = " + type);
        Debug.Log(gameObject.GetComponent<Image>().sprite.ToString());

    }

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(use_card);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void use_card() {
        PlayerController player = Game.get_current_player().GetComponent<PlayerController>();

        switch (type) {
            case "knight":
                player.knight_count++;
                player.remove_card(type);
                GameObject.Find("Robber").GetComponent<RobberController>().trigger_robber();
                GameObject.Find("UI").GetComponent<InventoryUIController>().close_inventory();
                break;
            case "monopoly":
                Game.turn_state = Game.TurnStates.stealing;
                Game.monopoly_panel.SetActive(true);
                player.remove_card(type);
                GameObject.Find("UI").GetComponent<InventoryUIController>().close_inventory();
                break;
            case "road_building":
                player.remove_card(type);
                Game.road_building = true;
                Game.turn_state = Game.TurnStates.road;
                GameObject.Find("UI").GetComponent<InventoryUIController>().close_inventory();
                break;
            case "year_of_plenty":
                // TODO Add year of plenty
                player.remove_card(type);
                GameObject.Find("UI").GetComponent<InventoryUIController>().close_inventory();
                break;
        }
    }
 }
