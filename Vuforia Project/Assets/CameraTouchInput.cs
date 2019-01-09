using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTouchInput : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit))
            {
                print(hit.transform.gameObject.name);
            }
        }
	}
}
