using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionFX : MonoBehaviour
{

/////////////////START OF SCRIPT///////////////////////////

//////////////////////////////////////////////////////////

///////////WHERE TO PUT VARRIBLES///////////////////////////
private float shakeTimeRemaining;
private float shakePower;
private float shakeFadeTime;
private float shakeRotation;
public float rotationMultiplier;

public float shakeLength;
public float shakeStrength;
public AudioSource micCollision;
public GameObject playerCamera;

[SerializeField] ParticleSystem collectParticle = null;

public Transform resetTargetPoint;

public GameObject MIC;

//public  CollisionFX instance;

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

    private void FixedUpdate()
    {
        if  (shakeTimeRemaining     >       0)
        {
            shakeTimeRemaining -=Time.deltaTime;

            float xAmount = Random.RandomRange(-1f  ,   1f) * shakePower;
            float yAmount = Random.RandomRange(-1f  ,   1f) * shakePower;
            playerCamera.transform.position += new Vector3(xAmount    ,   yAmount,    0f);
            shakePower  = Mathf.MoveTowards(shakePower  ,   0.0f,   shakeFadeTime * Time.deltaTime);
            shakeRotation   =   Mathf.MoveTowards(shakeRotation ,   0f  ,   shakeFadeTime   *   rotationMultiplier  *   Time.deltaTime);
        }
        transform.rotation = Quaternion.Euler(0f    ,   0f      ,   shakeRotation   *   Random.RandomRange(-1f  ,   1f));
    }


    public void StartShakeEffect(float length, float power)
    {
        shakeTimeRemaining = length;
        shakePower = power;
        shakeFadeTime = power / length;
        shakeRotation   =   power*  rotationMultiplier;
    }



  void OnCollisionEnter (Collision collisionInfo)
        {
            
            //Debug.Log(collisionInfo.collider.name);
            collectParticle.Play();
            StartShakeEffect(shakeLength    ,   shakeStrength);
            //StartCoroutine  (cameraShake.Shake(.15f,    .4f));
            //CameraShaker.Instance.ShakeOnce(magnitude, roughness, fadeInTime,    fadeOutTime);
            //Time.timeScale  =   0.2f;
            micCollision.Play();
        }
    void OnTriggerEnter (Collider trigger)
        {
            if  (trigger.gameObject.tag == "Hazard")
            {
            MIC.transform.position = resetTargetPoint.transform.position;
            micCollision.Play();
            }
        }

    void OnCollisionStay (Collision collisionInfo)
        {
            //Time.timeScale  =   1f;
        }
        void OnCollisionExit (Collision collisionInfo)
        {
            //Time.timeScale  =   1f;
        }

















/////////////////END OF SCRIPT///////////////////////////    
}






///The old Method//////////////
/* 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
public class CollisionFX : MonoBehaviour
{
    [SerializeField] ParticleSystem collectParticle = null;
    public float magnitude = 0.0f;
    public float roughness = 0.0f;
    public float fadeInTime = 0.0f;
    public float fadeOutTime = 0.0f;

    public float mag;
    //public CameraShake cameraShake;

        void Update()
        {
            float mag = GetComponent<Rigidbody>().velocity.magnitude;
        }

        void OnCollisionEnter (Collision collisionInfo)
        {
            //Debug.Log(collisionInfo.collider.name);
            collectParticle.Play();
            //StartCoroutine  (cameraShake.Shake(.15f,    .4f));
            CameraShaker.Instance.ShakeOnce(magnitude, roughness, fadeInTime,    fadeOutTime);
            //Time.timeScale  =   0.4f;
        }
        void OnCollisionExit (Collision collisionInfo)
        {
            //Time.timeScale  =   1f;
        }

        
}
 */
///The old Method//////////////
