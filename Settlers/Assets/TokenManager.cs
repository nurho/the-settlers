using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sets up the dice roll tokens on the board.
/// </summary>
public class TokenManager : MonoBehaviour
{
    // ----------------
    //    Variables
    // ----------------

    // Declare containers for token objects.
    GameObject number_2_token;
    List<GameObject> number_3_tokens;
    List<GameObject> number_4_tokens;
    List<GameObject> number_5_tokens;
    List<GameObject> number_6_tokens;
    List<GameObject> number_8_tokens;
    List<GameObject> number_9_tokens;
    List<GameObject> number_10_tokens;
    List<GameObject> number_11_tokens;
    GameObject number_12_token;

    // Positions of the tokens on the board.
    float[,] positions = BoardData.tile_positions;


    // ----------------
    //     Methods
    // ----------------

    /// <summary>
    /// Finds and assigns the token objects.
    /// </summary>
    public void setup_tokens() {
        number_2_token = GameObject.Find("Token_2");
        number_3_tokens = new List<GameObject> { GameObject.Find("Token_3_1"), GameObject.Find("Token_3_2") };
        number_4_tokens = new List<GameObject> { GameObject.Find("Token_4_1"), GameObject.Find("Token_4_2") };
        number_5_tokens = new List<GameObject> { GameObject.Find("Token_5_1"), GameObject.Find("Token_5_2") };
        number_6_tokens = new List<GameObject> { GameObject.Find("Token_6_1"), GameObject.Find("Token_6_2") };
        number_8_tokens = new List<GameObject> { GameObject.Find("Token_8_1"), GameObject.Find("Token_8_2") };
        number_9_tokens = new List<GameObject> { GameObject.Find("Token_9_1"), GameObject.Find("Token_9_2") };
        number_10_tokens = new List<GameObject> { GameObject.Find("Token_10_1"), GameObject.Find("Token_10_2") };
        number_11_tokens = new List<GameObject> { GameObject.Find("Token_11_1"), GameObject.Find("Token_11_2") };
        number_12_token = GameObject.Find("Token_12");
    }

    /// <summary>
    /// Places the token objects on the board in the correct layout.
    /// </summary>
    /// <param name="layout">A list of integers providing the layout of the tokens.</param>
    public void place_tokens(List<int> layout) {
        // Loop through the layout and place the tokens in the corresponding position
        int i = 0;
        foreach (int j in layout) {
            switch (j) {
                case 0:
                    GameObject.Find("Robber").transform.position = new Vector2(positions[i, 0] + 0.2f, positions[i, 1] - 0.2f);
                    break;
                case 2:
                    number_2_token.transform.position = new Vector2(positions[i, 0], positions[i, 1]);
                    break;
                case 3:
                    number_3_tokens[0].transform.position = new Vector2(positions[i, 0], positions[i, 1]);
                    number_3_tokens.RemoveAt(0);
                    break;
                case 4:
                    number_4_tokens[0].transform.position = new Vector2(positions[i, 0], positions[i, 1]);
                    number_4_tokens.RemoveAt(0);
                    break;
                case 5:
                    number_5_tokens[0].transform.position = new Vector2(positions[i, 0], positions[i, 1]);
                    number_5_tokens.RemoveAt(0);
                    break;
                case 6:
                    number_6_tokens[0].transform.position = new Vector2(positions[i, 0], positions[i, 1]);
                    number_6_tokens.RemoveAt(0);
                    break;
                case 8:
                    number_8_tokens[0].transform.position = new Vector2(positions[i, 0], positions[i, 1]);
                    number_8_tokens.RemoveAt(0);
                    break;
                case 9:
                    number_9_tokens[0].transform.position = new Vector2(positions[i, 0], positions[i, 1]);
                    number_9_tokens.RemoveAt(0);
                    break;
                case 10:
                    number_10_tokens[0].transform.position = new Vector2(positions[i, 0], positions[i, 1]);
                    number_10_tokens.RemoveAt(0);
                    break;
                case 11:
                    number_11_tokens[0].transform.position = new Vector2(positions[i, 0], positions[i, 1]);
                    number_11_tokens.RemoveAt(0);
                    break;
                case 12:
                    number_12_token.transform.position = new Vector2(positions[i, 0], positions[i, 1]);
                    break;
                default:
                    break;
            }
            i++;
        }
    }
}