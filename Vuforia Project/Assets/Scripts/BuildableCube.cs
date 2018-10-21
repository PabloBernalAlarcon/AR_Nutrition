using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildableCube : MonoBehaviour {

    public Vector3[] Faces;

  
	// Use this for initialization
	void Start () {
        Faces = new Vector3[6];
        updateFaces();
	}

    void updateFaces()
    {

        //z axis
        Faces[0] = transform.forward;
        Faces[1] = -Faces[0];

        //y axis
        Faces[2] = transform.up;
        Faces[3] = -Faces[2];

        //x axis
        Faces[4] = transform.right;
        Faces[5] = -Faces[4];
    }

   /* private void Update()
    {
        updateFaces();

        transform.Rotate(0,Time.deltaTime* 3, 0);
    }*/
}
