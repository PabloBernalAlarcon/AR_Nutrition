using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonMoon : MonoBehaviour {

    [SerializeField]
    Transform toFollow;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = toFollow.position;
	}
}
