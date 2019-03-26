using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGrid : MonoBehaviour {

    [SerializeField]
    GameObject CubeForGrid;
    [SerializeField]
    uint X;
    [SerializeField]
    uint Y;

    GameObject[,] grid;

    Vector3 startingPos;
	// Use this for initialization
	void Start () {
        //transform.parent = CubeForGrid.transform;
        startingPos = transform.position;
        float OffsetX = transform.localScale.x;
        float OffsetZ = transform.localScale.z;

        grid = new GameObject[X,Y];

        for (int i = 0; i < X; i++)
        {
            for (int j = 0; j < Y; j++)
            {
                GameObject t = Instantiate(CubeForGrid, this.transform);
                t.transform.position = startingPos;
                startingPos.z += OffsetZ;
            }

            startingPos.x += OffsetX;
            startingPos.z = 0;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
