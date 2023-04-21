using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the turn indicator UI element.
/// </summary>
public class TurnIndicator : MonoBehaviour
{
    // ----------------
    //     Methods
    // ----------------

    /// <summary>
    /// Move the indicator to the required players UI panel.
    /// </summary>
    /// <param name="player_turn">Player number of whose turn it is.</param>
    public void set_indicator(int player_turn) {
        Vector3 pos = this.gameObject.GetComponent<RectTransform>().localPosition;
        if (player_turn == 0) {
            this.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(pos.x, 100f, pos.z);
        } else if (player_turn == 1) {
            this.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(pos.x, 40f, pos.z);
        } else if (player_turn == 2) {
            this.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(pos.x, -20f, pos.z);
        } else if (player_turn == 3) {
            this.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(pos.x, -80f, pos.z);
        }
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
