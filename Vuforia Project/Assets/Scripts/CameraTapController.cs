using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTapController : MonoBehaviour {

    
        Camera camera;
    Transform objectHit;

        void Start()
        {
        camera = GetComponent<Camera>();

          
        }

  /**  private void Update()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
       
        
        if (Physics.Raycast(ray, out hit))
        {
            objectHit = hit.transform;

            if (objectHit.tag != "Shrek")
                objectHit = null;

            print(objectHit.tag);
           
        }

        if (Input.GetKey(KeyCode.Mouse0) && objectHit != null)
        {
            Vector3 newpos = camera.ScreenToWorldPoint(Input.mousePosition);
            objectHit.position = new Vector3(newpos.x, newpos.y, objectHit.position.z);
        }
    }**/

}
