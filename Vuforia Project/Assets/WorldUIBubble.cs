using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldUIBubble : MonoBehaviour {

    [SerializeField]
    Transform cam;

	
	
	// Update is called once per frame
	void Update () {

        Vector3 targetPostition = new Vector3(-cam.position.x,
                                       this.transform.position.y,
                                       -cam.position.z);
        this.transform.LookAt(targetPostition);
	}
}
