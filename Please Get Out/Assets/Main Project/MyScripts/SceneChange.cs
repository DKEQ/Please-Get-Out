using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Threading.Tasks;
public class SceneChange : MonoBehaviour
{
/////////////////////////START OF CODE///////////////////////
    public static SceneChange instance;





//////////////////WHERE TO PLACE VARRIBLES///////////////////////
    //public int sceneNumber;





//////////////////WHERE FUNCTIONS HAPPEN////////////////////////
void Awake()
    {   
        instance = this;
    }
///////////////LOADING LEVELS FROM EACH LEVEL////////////////
    public void L1 ()
    {
        GameManager.instance.LoadLEVEL_1();
    }

    public void L2 ()
    {
        GameManager.instance.LoadLEVEL_2();
    }
    public void L3 ()
    {
        GameManager.instance.LoadLEVEL_3();
    }
    public void L4 ()
    {
        GameManager.instance.LoadLEVEL_4();
    }
    public void L5 ()
    {
        GameManager.instance.LoadLEVEL_5();
    }
    public void L6 ()
    {
        GameManager.instance.LoadLEVEL_6();
    }
    public void L7 ()
    {
        GameManager.instance.LoadLEVEL_7();
    }
    public void L8 ()
    {
        GameManager.instance.LoadLEVEL_8();
    }
    public void L9 ()
    {
        GameManager.instance.LoadLEVEL_9();
    }
    public void L10 ()
    {
        GameManager.instance.LoadLEVEL_10();
    }
    
///////////////////////////////////////////////////////

//////////////RESTARTING LEVELS FROM EACH LEVEL
public void R_L1 ()
    {
        GameManager.instance.LEVEL_1_RestartProceedure();
    }

    public void R_L2 ()
    {
        //GameManager.instance.LoadLEVEL_2();
        GameManager.instance.LEVEL_2_RestartProceedure();
    }
    public void R_L3 ()
    {
        //GameManager.instance.LoadLEVEL_3();
        GameManager.instance.LEVEL_3_RestartProceedure();
    }
    public void R_L4 ()
    {
        //GameManager.instance.LoadLEVEL_4();
        GameManager.instance.LEVEL_4_RestartProceedure();
    }
    public void R_L5 ()
    {
        //GameManager.instance.LoadLEVEL_5();
        GameManager.instance.LEVEL_5_RestartProceedure();
    }
    public void R_L6 ()
    {
        //GameManager.instance.LoadLEVEL_6();
        GameManager.instance.LEVEL_6_RestartProceedure();
    }
    public void R_L7 ()
    {
        //GameManager.instance.LoadLEVEL_7();
        GameManager.instance.LEVEL_7_RestartProceedure();
    }
    public void R_L8 ()
    {
        //GameManager.instance.LoadLEVEL_8();
        GameManager.instance.LEVEL_8_RestartProceedure();
    }
    public void R_L9 ()
    {
        //GameManager.instance.LoadLEVEL_9();
        GameManager.instance.LEVEL_9_RestartProceedure();
    }
    public void R_L10 ()
    {
        //GameManager.instance.LoadLEVEL_110();
        GameManager.instance.LEVEL_10_RestartProceedure();
    }
///////////////////////////////////////////////////






//////////////UNLOAD CURRENT SCENES////////////////
    public void U_L1 ()
    {
        GameManager.instance.LEVEL_1_CompleteUnLoadProceedure();
    }

    public void U_L2 ()
    {
        //GameManager.instance.LoadLEVEL_2();
        GameManager.instance.LEVEL_2_CompleteUnLoadProceedure();
    }
    public void U_L3 ()
    {
        //GameManager.instance.LoadLEVEL_3();
        GameManager.instance.LEVEL_3_CompleteUnLoadProceedure();
    }
    public void U_L4 ()
    {
        //GameManager.instance.LoadLEVEL_4();
        GameManager.instance.LEVEL_4_CompleteUnLoadProceedure();
    }
    public void U_L5 ()
    {
        //GameManager.instance.LoadLEVEL_5();
        GameManager.instance.LEVEL_5_CompleteUnLoadProceedure();
    }
    public void U_L6 ()
    {
        //GameManager.instance.LoadLEVEL_6();
        GameManager.instance.LEVEL_6_CompleteUnLoadProceedure();
    }
    public void U_L7 ()
    {
        //GameManager.instance.LoadLEVEL_7();
        GameManager.instance.LEVEL_7_CompleteUnLoadProceedure();
    }
    public void U_L8 ()
    {
        //GameManager.instance.LoadLEVEL_8();
        GameManager.instance.LEVEL_8_CompleteUnLoadProceedure();
    }
    public void U_L9 ()
    {
        //GameManager.instance.LoadLEVEL_9();
        GameManager.instance.LEVEL_9_CompleteUnLoadProceedure();
    }
    public void U_L10 ()
    {
        //GameManager.instance.LoadLEVEL_10();
        GameManager.instance.LEVEL_10_CompleteUnLoadProceedure();
    }

////////////////////////////////////////////////////

    public void L_MM   ()
    {
        GameManager.instance.LoadMain_Menu_From_AnyScene();
        
    }

    public void L_MM_F_L10  ()
    {
        GameManager.instance.LoadMain_MenuFrom_Level_10();
    }

    public void L2_DM     ()
    {
        GameManager.instance.LoadLEVEL_2_DevMode();
    }

    public void L3_DM     ()
    {
        GameManager.instance.LoadLEVEL_3_DevMode();
    }

    public void L4_DM     ()
    {
        GameManager.instance.LoadLEVEL_4_DevMode();
    }

    public void L5_DM     ()
    {
        GameManager.instance.LoadLEVEL_5_DevMode();
    }

    public void L6_DM     ()
    {
        GameManager.instance.LoadLEVEL_6_DevMode();
    }

    public void L7_DM     ()
    {
        GameManager.instance.LoadLEVEL_7_DevMode();
    }

    public void L8_DM     ()
    {
        GameManager.instance.LoadLEVEL_8_DevMode();
    }

    public void L9_DM     ()
    {
        GameManager.instance.LoadLEVEL_9_DevMode();
    }

    public void L10_DM     ()
    {
        GameManager.instance.LoadLEVEL_10_DevMode();
    }

    /* public void Tog    ()
    {
        GameManager.instance.ToggleValueChangedOccured();
    } */





















/////////////////////////END OF CODE///////////////////////
}
