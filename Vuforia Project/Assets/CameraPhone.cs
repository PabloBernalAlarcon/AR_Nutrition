using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPhone : MonoBehaviour {
 float rotx = 0;
 float roty  = 0;
 float rotz  = 0;
 float rotw  = 0;
 
 void Start()
    {
       // Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

   void FixedUpdate()
    {
        rotx = -Input.acceleration.x;
        roty = Input.acceleration.y;
        rotz = Input.acceleration.z;
        transform.rotation = new Quaternion(rotx, roty, rotz, rotw);

       
    }
}
