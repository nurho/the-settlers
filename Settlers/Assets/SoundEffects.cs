using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioClip select;
    public AudioClip place;
    public AudioClip invalid;
    public AudioClip roll;

    AudioSource sfx_source;

    public void select_sound() {
        sfx_source.pitch = 1;
        sfx_source.PlayOneShot(select);
    }

    public void place_sound() {
        sfx_source.pitch = 1;
        sfx_source.PlayOneShot(place);
    }

    public void invalid_sound() {
        sfx_source.pitch = 1;
        sfx_source.PlayOneShot(invalid);
    }

    public void roll_sound() {
        sfx_source.pitch = 2;
        sfx_source.PlayOneShot(roll);
    }

    // Start is called before the first frame update
    void Start()
    {
        sfx_source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
