using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controls the behaviour of the main menu UI
/// </summary>
public class MainMenuController : MonoBehaviour
{
    // ----------------
    //    Methods
    // ----------------

    /// <summary>
    /// Loads the basic (beginner) layout.
    /// </summary>
    public void beginner_3_player_button() {
        Game.num_players = 3;
        SceneManager.LoadScene("Scene1");
    } 
    
    public void beginner_4_player_button() {
        Game.num_players = 4;
        SceneManager.LoadScene("Scene1");
    }

    public void quit_button() {
        Application.Quit();
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
