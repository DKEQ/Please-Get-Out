using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraShake : MonoBehaviour
{

/////////////////START OF SCRIPT///////////////////////////

//////////////////////////////////////////////////////////

///////////WHERE TO PUT VARRIBLES///////////////////////////
public float shakeTimeRemaining;
public float shakePower;
public GameObject playerCamera;
////////////////////////////////////////////////////////////








/////////////WHERE TO PUT FUNCTIONS////////////////////////////
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if  (shakeTimeRemaining     >       0)
        {
            shakeTimeRemaining -=Time.deltaTime;

            float xAmount = Random.RandomRange(-1f  ,   1f) * shakePower;
            float yAmount = Random.RandomRange(-1f  ,   1f) * shakePower;
            playerCamera.transform.position += new Vector3(xAmount    ,   yAmount,    0f);

        }
    }


    public void StartShakeEffect(float length, float power)
    {
        shakeTimeRemaining = length;
        shakePower = power;
    }





















/////////////////END OF SCRIPT///////////////////////////    
}
