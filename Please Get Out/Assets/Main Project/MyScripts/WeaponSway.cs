using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    Quaternion normalRot;           //normal rotation is recorded at the start of the game
    public float rotX, rotY;        //the amount your model will rotate on the X and the Y axes
    float tiltX, tiltY;             //current angle of model
    public float rotationSmooth;    //how fast/slow the object will rotate back to its normal position
    public float maxRot;            //maximum angle the object can rotate (to prevent seeing wrong parts of the object)

    //GameManager gM;

    void Start()
    {
        normalRot = transform.rotation;
    }

    void FixedUpdate()
    {
        if  (!PauseMenuUI.isPaused)
        { 
        tiltX = +Input.GetAxis("Mouse X") * rotX;
        tiltY = +Input.GetAxis("Mouse Y") * rotY;

        Quaternion target = Quaternion.Euler(Mathf.Clamp(tiltY, -maxRot, maxRot) / 1.5f, -Mathf.Clamp(tiltX, -maxRot, maxRot) / 1.5f, Mathf.Clamp(tiltX, -maxRot, maxRot) / 1.5f);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, target, rotationSmooth * Time.smoothDeltaTime);
        }
    }
}
