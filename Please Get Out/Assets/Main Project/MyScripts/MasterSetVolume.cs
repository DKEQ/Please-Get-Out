using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class MasterSetVolume : MonoBehaviour
////////////////////////////////START OF SCRIPT////////////////////////////////
{
//Variables to tell stuff what to do
    public AudioMixer mixer;
    public void SetAudioLayer1 (float sliderValue)
    {
        mixer.SetFloat ("MasterVol", Mathf.Log10 (sliderValue) * 20);
        mixer.SetFloat ("MusicVol", Mathf.Log10 (sliderValue) * 20);
        mixer.SetFloat ("SFXVol", Mathf.Log10 (sliderValue) * 20);
    } 
















}
////////////////////////////////END OF SCRIPT////////////////////////////////