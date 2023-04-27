using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonopolyPanelController : MonoBehaviour
{
    public void monopoly_button() {
        string resource = "";
        switch (GameObject.Find("MonopolyDropdown").GetComponent<Dropdown>().value) {
            case 0:
                resource = "lumber";
                break;
            case 1:
                resource = "brick";
                break;
            case 2:
                resource = "wool";
                break;
            case 3:
                resource = "grain";
                break;
            case 4:
                resource = "ore";
                break;
        }


        int total = 0;

        foreach (GameObject player_object in Game.players) {
            PlayerController player = player_object.GetComponent<PlayerController>();

            if (player.gameObject != Game.get_current_player()) {
                int n = player.check_resource(resource);
                total += n;
                player.give_resource(resource, -n);
            }
        }

        Game.get_current_player().GetComponent<PlayerController>().give_resource(resource, total);
        Game.turn_state = Game.TurnStates.general;
        Game.monopoly_panel.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
