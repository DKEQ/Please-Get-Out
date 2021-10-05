using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicJustForLevel_10 : MonoBehaviour
{
    /////////////////START OF CODE///////////////////

/////////////////////////////////////////////////

/////////////////Varribles///////////////////
public AudioSource musicPlayer;
public AudioSource sfxPlayer;

public float startPitch;
public float endPitch;

public float increaseAmount;
/////////////////////////////////////////////////

///////////////START OF FUNCTIONS//////////////////
    // Start is called before the first frame update
    void Awake()
    {
        //musicPlayer.pitch = Random.Range(minPitch,maxPitch);
        musicPlayer.pitch = startPitch;
        
    }


    void Update()
    {
        //sfxPlayer.pitch = Random.Range(minPitch,maxPitch);
        if  (musicPlayer.pitch <= 0.575f)
        {
            musicPlayer.pitch += 0.002f *   Time.deltaTime;
            //musicPlayer.pitch = increaseAmount;
        }
        else if  (musicPlayer.pitch <= 1f)
        {
            musicPlayer.pitch += 0.04f * Time.deltaTime;
        }
        else
        {
            Debug.Log("Okay");
        }
        //increaseAmount += Time.deltaTime;
    }



































}
/////////////////END OF CODE///////////////////
