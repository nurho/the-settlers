using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileController : MonoBehaviour {

    public string tile_token;
    public List<GameObject> adjacent_intersections = new List<GameObject>();

    public void add_adjacent_intersections(List<GameObject> intersections) {
        foreach (GameObject intersection in intersections) {
            adjacent_intersections.Add(intersection);
        }
    }

    // Start is called before the first frame update
    void Start() {


    }

    // Update is called once per frame
    void Update() {

    }

    private void OnMouseEnter() {
        if (Game.turn_state == Game.TurnStates.robber && Game.robber_location != tile_token) {
            Game.current_tile = this.gameObject;
            Game.valid_move = true;
        }
    }

    private void OnMouseExit() {
        if (Game.turn_state == Game.TurnStates.robber) {
            Game.valid_move = false;
        }
    }
}
