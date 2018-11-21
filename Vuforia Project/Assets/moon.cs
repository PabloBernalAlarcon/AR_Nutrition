using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moon : MonoBehaviour {

    [SerializeField]
    Transform cam;
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.LookAt(cam);
	}
}
