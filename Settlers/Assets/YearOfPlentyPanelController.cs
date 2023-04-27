using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class YearOfPlentyPanelController : MonoBehaviour
{

    public void year_of_plenty_button() {
        string resource1 = "";
        string resource2 = "";

        switch (GameObject.Find("YearOfPlentyDropdown1").GetComponent<Dropdown>().value) {
            case 0:
                resource1 = "lumber";
                break;
            case 1:
                resource1 = "brick";
                break;
            case 2:
                resource1 = "wool";
                break;
            case 3:
                resource1 = "grain";
                break;
            case 4:
                resource1 = "ore";
                break;
        }

        switch (GameObject.Find("YearOfPlentyDropdown2").GetComponent<Dropdown>().value) {
            case 0:
                resource2 = "lumber";
                break;
            case 1:
                resource2 = "brick";
                break;
            case 2:
                resource2 = "wool";
                break;
            case 3:
                resource2 = "grain";
                break;
            case 4:
                resource2 = "ore";
                break;
        }

        Game.get_current_player().GetComponent<PlayerController>().give_resource(resource1, 1);
        Game.get_current_player().GetComponent<PlayerController>().give_resource(resource2, 1);
        Game.turn_state = Game.TurnStates.general;
        Game.year_of_plenty_panel.SetActive(false);

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
