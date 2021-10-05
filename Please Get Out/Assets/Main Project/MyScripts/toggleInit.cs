using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggleInit : MonoBehaviour
{
/////////////////////////START OF CODE///////////////////////
    public static toggleInit instance;
    public GameObject start_ToggleA;
    public GameObject start_ToggleB;
    public Toggle tog;
    public string playerPrefName;




//////////////////WHERE TO PLACE VARRIBLES///////////////////////
    //public int sceneNumber;





//////////////////WHERE FUNCTIONS HAPPEN////////////////////////
void Awake()
    {   
        instance = this;
        start_ToggleA.SetActive(true);
        start_ToggleB.SetActive(false);

        //tog = GetComponent<Toggle>();
        tog.isOn = IntToBool(PlayerPrefs.GetInt(playerPrefName , 0));
    }
///////////////INITIALIZE TASKS////////////////


public void Init_Toggle_CB(bool tglValue)
    {
        GameManager.instance.ToggleValueChangedOccured(tglValue);
        PlayerPrefs.SetInt(playerPrefName   ,   BoolToInt(tglValue));
    }

public void Start_Option_ToggleBetween(bool startTog)
    {
        start_ToggleA.SetActive(!startTog);
        start_ToggleB.SetActive(startTog);
        PlayerPrefs.SetInt(playerPrefName   ,   BoolToInt(startTog));
    }

public void Windowed_Mode_Toggle(bool windowTog)
    {
        Screen.fullScreen = !Screen.fullScreen;
        PlayerPrefs.SetInt(playerPrefName   ,   BoolToInt(windowTog));
    }

public bool IntToBool(int n)
    {
        if (n == 0)
        {
            return false;
        }
        return true;
    }

public int BoolToInt(bool b)
    {
        if (b)
        {
            return 1;
        }
        return 0;
    }




















////////////////END OF SCRIPT///////////////////////////////
}
