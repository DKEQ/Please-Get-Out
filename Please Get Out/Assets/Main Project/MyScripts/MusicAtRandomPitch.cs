using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAtRandomPitch : MonoBehaviour
{
    /////////////////START OF CODE///////////////////

/////////////////////////////////////////////////

/////////////////Varribles///////////////////
public AudioSource musicPlayerByFloat;
public AudioSource musicPlayerByInt;

public float minPitchByFloat;
public float maxPitchByFloat;

public int minPitchByInt;
public int maxPitchByInt;
/////////////////////////////////////////////////

///////////////START OF FUNCTIONS//////////////////
    // Start is called before the first frame update
    void Awake()
    {
        musicPlayerByFloat.pitch = Random.Range(minPitchByFloat,maxPitchByFloat);
        musicPlayerByInt.pitch = Random.Range(minPitchByInt,maxPitchByInt);
        
    }


    void Update()
    {
        //sfxPlayer.pitch = Random.Range(minPitch,maxPitch);
    }



































}
/////////////////END OF CODE///////////////////
