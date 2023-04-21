using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls displaying the build costs card.
/// </summary>
public class BuildCostsImage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Show the card when the space bar is held.
        if (Input.GetKeyDown(KeyCode.Space)) {
            this.GetComponent<Image>().enabled = true;
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            this.GetComponent<Image>().enabled = false;
        }
    }
}
