using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersistentSlider : MonoBehaviour
{
    public Slider slider;
    public float defaultValue;
    public string playerPrefsKey;



    public void OnEnable() {
        //slider = GetComponent<Slider>();
        slider.value = PlayerPrefs.GetFloat(playerPrefsKey, defaultValue);
        
    }

    public void OnDisable() {
        PlayerPrefs.SetFloat(playerPrefsKey, slider.value);
    }

}