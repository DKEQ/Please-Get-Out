using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class SettingsMenuPersistance : MonoBehaviour
{
///////////////////////////////START OF THE CODE//////////////////////////

//////////////////////////////////////////////////////////////////////////
// You need to:
// - Have a varribles for each slider
// - Have the options be persistent between The main manu and the pause menu
// - Cut out options that would not be possible to carry over like DEV mode in the Pause menu
/////////////////////////////START OF VARRIBLES///////////////////////////
        static SettingsMenuPersistance instance;
        /* public  Slider volumeSFX_Slider;
        public  Slider volumeMusic_Slider;
        public  Slider volumeMaster_Slider;
        public  AudioSource sfx_AS;
        public  AudioSource music_AS;
        public  AudioSource master_AS;

        public static float SFXValue;
        public static float MusicValue;
        public static float MasterValue; */

        public Toggle colourBlindMode;
        public Slider vol_SFX;
        public Slider vol_Music;
        public Slider vol_Master;
        public  AudioSource sfx_AS;
        public  AudioSource music_AS;
        public  AudioSource master_AS;

//////////////////////////////////////////////////////////////////////////


///////////////////////////////START OF FUNCTIONS//////////////////////////

    void    Awake()
    {
        /* vol_SFX =   GameObject.Find("SFX Volume Slider").GetComponent<Slider>();
        vol_Music =   GameObject.Find("Music Volume Slider").GetComponent<Slider>();
        vol_Master =   GameObject.Find("Master Volume Slider").GetComponent<Slider>();

        sfx_AS =   GameObject.Find("SFX Volume Slider").GetComponent<AudioSource>();
        music_AS =   GameObject.Find("Music Volume Slider").GetComponent<AudioSource>();
        master_AS =   GameObject.Find("Master Volume Slider").GetComponent<AudioSource>(); */

        /* vol_SFX =   GetComponent<SFXVolumeSlider>();

        vol_Music =   GameObject.Find("Music Volume Slider").GetComponent<Slider>();
        vol_Master =   GameObject.Find("Master Volume Slider").GetComponent<Slider>();

        sfx_AS =   GameObject.Find("SFX Volume Slider").GetComponent<AudioSource>();
        music_AS =   GameObject.Find("Music Volume Slider").GetComponent<AudioSource>();
        master_AS =   GameObject.Find("Master Volume Slider").GetComponent<AudioSource>();
 */
    }

    void    update()
    {
        /* sfx_AS.volume = vol_SFX.value;
        music_AS.volume = vol_Music.value;
        master_AS.volume = vol_Master.value;

        vol_SFX.value = PlayerPrefs.GetFloat("sfx_Volume");
        vol_Music.value = PlayerPrefs.GetFloat("music_Volume");
        vol_Master.value = PlayerPrefs.GetFloat("master_Volume"); */

        
    } 

    public void VolumePrefs()
    {
        /* PlayerPrefs.SetFloat("sfx_Volume",sfx_AS.volume);
        PlayerPrefs.SetFloat("music_Volume",music_AS.volume);
        PlayerPrefs.SetFloat("master_Volume",master_AS.volume); */
    }










///////////////////////////////END OF THE CODE//////////////////////////
}
