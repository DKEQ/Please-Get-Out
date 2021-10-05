using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SetVolume_SFX : MonoBehaviour
////////////////////////////////START OF SCRIPT////////////////////////////////
{
//Variables to tell stuff what to do
    public AudioMixer mixer;
    public void SetAudioLayer3 (float sliderValue)
    {
        mixer.SetFloat ("SFXVol", Mathf.Log10 (sliderValue) * 20);
    } 
















}
////////////////////////////////END OF SCRIPT////////////////////////////////