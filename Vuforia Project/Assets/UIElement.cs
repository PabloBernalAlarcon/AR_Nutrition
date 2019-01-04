using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElement : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        GameOverseer.instance.AddUIItem(this.gameObject);
	}
	
	
}
