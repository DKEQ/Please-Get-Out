using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Rotation_Behaviour : MonoBehaviour
////////////////////////////////START OF SCRIPT////////////////////////////////
{
//Variables to tell stuff what to do
public float rotationSpeed = 1f;
public float xMultiplier = 2f;
public float yMultiplier = 2f;
public float minRotation = 0;
public float maxRotation = 0;
    
/*     if(Input.GetAxis("Mouse X") != 1 || Input.GetAxis("Mouse Y") != 1)
{
 float XaxisRotation = Input.GetAxis("Mouse X") * rotationSpeed;
    float YaxisRotation = Input.GetAxis("Mouse Y") * rotationSpeed;

    transform.Rotate(Vector3.down, XaxisRotation);
	  transform.Rotate(Vector3.right, YaxisRotation);
      print("ligma");
       
}
 */
 

    void Start()
    {
        


    }
    //Updates with Framerate
     void FixedUpdate()
    {
        //float translation is just the name of a in function varriable to make
        //it easier to type but is otherwise irrelevant
        //float translation = Input.GetAxis("Horizontal") * rotationSpeed;
        //translation *= -Time.deltaTime;

        //Rotates Transform Object by getting the Axial Input info from the X and Y axis of the mouse when it moves
        
        transform.Rotate((-Input.GetAxis("Mouse Y") * rotationSpeed * yMultiplier  * -Time.smoothDeltaTime), (Input.GetAxis("Mouse X") * rotationSpeed * xMultiplier * -Time.smoothDeltaTime), 0, Space.Self);


        //float minRotation = -45;
        //float maxRotation = 45;
        //and calculate its change in position as the force needed to move using Vector 3
        //against its current movement in the x and y axis. Mathf.Clamp applies a
        //restriction for the min and maximum rotation that is allowed for the object
        //before it is stopped
        //This uses Euler equations and Quaternion representation or rotations to identify
        //and apply the clamps and calculations for the rotations whilst ensuring the limit is not surpassed
        Vector3 currentRotation = transform.localRotation.eulerAngles;
        currentRotation.x = Mathf.Clamp(currentRotation.x, minRotation, maxRotation);
        currentRotation.y = Mathf.Clamp(currentRotation.y, minRotation, maxRotation);
        transform.localRotation = Quaternion.Euler (currentRotation);
    }
}

////////////////////////////////END OF SCRIPT////////////////////////////////

