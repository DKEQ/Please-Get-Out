using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewHeadBobAndBreathing : MonoBehaviour
////////////////////////////////START OF SCRIPT////////////////////////////////  
{
////////////////Place to put variables//////////////////
        public Transform weaponParent;    
        private Vector3 weaponParentOrigin;

        private float movementCounter;
        private float idleCounter;

        private Vector3 targetWeaponBobPosition;
        public GameObject thePlayerController;
        public PlayerController playerControllerScript;
        /////////////HEADBOB CODING VARRIBLES//////////////////
        /////////////////////////////////////////////////////////
        [Tooltip("Default Settings:  idle_x_Multiplier  =   0.03f, idle_y_Multiplier  =   0.03f, idle_TimeScale1_Multiplier  =   0f, idle_TimeScale2_Multiplier  =   2f, walking_x_Multiplier  =   0.04f, walking_y_Multiplier  =   0.04f, walking_TimeScale1_Multiplier  =   0f, walking_TimeScale2_Multiplier  =   6f, sprinting_x_Multiplier  =   0.15f, sprinting_y_Multiplier  =   0.075f, sprinting_TimeScale1_Multiplier  =   7f, sprinting_TimeScale2_Multiplier  =   10f")]
        public float idle_x_Multiplier  =   0.03f;
        public float idle_y_Multiplier  =   0.03f;
        public float idle_TimeScale1_Multiplier  =   1f;
        public float idle_TimeScale2_Multiplier  =   2f;
        /////////////////////////////////////////////
        public float walking_x_Multiplier  =   0.04f;
        public float walking_y_Multiplier  =   0.04f;
        public float walking_TimeScale1_Multiplier  =   1f;
        public float walking_TimeScale2_Multiplier  =   6f;
        /////////////////////////////////////////////////
        public float sprinting_x_Multiplier  =   0.15f;
        public float sprinting_y_Multiplier  =   0.075f;
        public float sprinting_TimeScale1_Multiplier  =   7f;
        public float sprinting_TimeScale2_Multiplier  =   10f;
////////////////Place to put functions//////////////////



        void Start()
        {
            weaponParentOrigin  =   weaponParent.localPosition;
            playerControllerScript = thePlayerController.GetComponent<PlayerController>();
        }

        void    Update()
        {
            float p_hmove = Input.GetAxisRaw("Horizontal");
            float p_vmove = Input.GetAxisRaw("Vertical");
            //Headbob
            if  (p_hmove    ==  0   &&  p_vmove ==  0) //IDLE 
            {
                HeadBob(idleCounter,    idle_x_Multiplier, idle_y_Multiplier);
                idleCounter +=  Time.deltaTime  *   idle_TimeScale1_Multiplier;
                weaponParent.localPosition  =   Vector3.Lerp(weaponParent.localPosition,    targetWeaponBobPosition,    Time.deltaTime  *   idle_TimeScale2_Multiplier);
            }
            else    if(thePlayerController.GetComponent<PlayerController>().isSprinting())//SPRINTING
            {
                HeadBob(movementCounter,    sprinting_x_Multiplier,   sprinting_y_Multiplier);
                movementCounter +=  Time.deltaTime  *   sprinting_TimeScale1_Multiplier;
                weaponParent.localPosition  =   Vector3.Lerp(weaponParent.localPosition,    targetWeaponBobPosition,    Time.deltaTime  *   sprinting_TimeScale2_Multiplier);
            }
            else if ((thePlayerController.GetComponent<PlayerController>().isWalking()))    //WALKING
            {
                HeadBob(movementCounter,    walking_x_Multiplier,   walking_y_Multiplier);
                movementCounter +=  Time.deltaTime  *   walking_TimeScale1_Multiplier;
                weaponParent.localPosition  =   Vector3.Lerp(weaponParent.localPosition,    targetWeaponBobPosition,    Time.deltaTime  *   walking_TimeScale2_Multiplier);  
            }
            
        }
        void    HeadBob(float p_z,  float   p_x_intensity, float    p_y_intensity)
        {
            targetWeaponBobPosition  =   weaponParentOrigin +   new Vector3  (Mathf.Cos(p_z)    *   p_x_intensity,    Mathf.Sin(p_z  *   2)  *   p_y_intensity,    0);
        }






}
////////////////////////////////END OF SCRIPT////////////////////////////////  