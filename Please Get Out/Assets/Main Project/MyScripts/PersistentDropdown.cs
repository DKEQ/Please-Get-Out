using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PersistentDropdown : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public int defaultValue;
    public string playerPrefsKey;



    public void OnEnable() {
       // dropdown = GetComponent<TMP_Dropdown>();
        dropdown.value = PlayerPrefs.GetInt(playerPrefsKey, defaultValue);
        
    }

    public void OnDisable() {
        PlayerPrefs.SetInt(playerPrefsKey, dropdown.value);
    }

}