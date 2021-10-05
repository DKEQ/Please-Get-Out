using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersistentToggle : MonoBehaviour
{
    public Toggle toggle;
    public bool defaultValue;
    public string playerPrefsKey;



    public void OnEnable() {
        toggle = GetComponent<Toggle>();
        toggle.isOn = IntToBool(PlayerPrefs.GetInt(playerPrefsKey, BoolToInt(defaultValue)));
        
    }

    public void OnDisable() {
        PlayerPrefs.SetInt(playerPrefsKey, BoolToInt(toggle.isOn));
    }

    private int BoolToInt(bool b) {
        if(b) {
            return 1;
        }
        
        return 0;
    }

    private bool IntToBool(int i) {
        if(i == 0) {
            return false;
        }
        
        return true;
    }
}