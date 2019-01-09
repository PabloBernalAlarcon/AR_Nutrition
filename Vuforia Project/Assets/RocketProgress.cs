using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RocketProgress : MonoBehaviour {

    [SerializeField]
    CPC_CameraPath Camerapath;


    Slider slider;
	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        slider.value = Camerapath.ProgressPercentage;
	}
}
