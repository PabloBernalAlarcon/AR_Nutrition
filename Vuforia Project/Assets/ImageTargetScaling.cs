using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageTargetScaling : MonoBehaviour {

    Vector3 InitialSize;
	// Use this for initialization
	void Start () {
        InitialSize = transform.localScale;
	}
	
	public void ChangeSize(Slider s)
    {
        transform.localScale = InitialSize * s.value;
    }
}
