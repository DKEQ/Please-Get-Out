using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SetVolume_Music : MonoBehaviour
////////////////////////////////START OF SCRIPT////////////////////////////////
{
//Variables to tell stuff what to do
    public AudioMixer mixer;
    //Audio Function to create an Audio Layer thats controllabe with a slider using 
    //float numbers
    public void SetAudioLayer2 (float sliderValue)
    {
        //This targets or sets the float of the exposed String value from the mixer to
        // Mathf.Log10 or Mathematics of logarithmic scale on to the sliderValue then multiplies
        //it by 20 to get normal numbers equal to what is apparent in the slider
        mixer.SetFloat ("MusicVol", Mathf.Log10 (sliderValue) * 20);
    } 
















}
////////////////////////////////END OF SCRIPT////////////////////////////////