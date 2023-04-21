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
    public void beginner_layout() {
        SceneManager.LoadScene("Scene1");
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
