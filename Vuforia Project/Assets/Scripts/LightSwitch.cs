using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LightSwitch : MonoBehaviour {

    RectTransform trans;
    public bool LightOn;
    public Image SignalLight;
    public ButtonControlPanel BCP;
	// Use this for initialization
	void Start () {
        trans = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Toggle()
    {
        LightOn = !LightOn;

        if (LightOn)
        {
            trans.eulerAngles = new Vector3(0, 180, 180);
            SignalLight.color = Color.green;
            GetComponent<AudioSource>().Play();
        }
        else
        {
            trans.eulerAngles = new Vector3(0,0,0);
            SignalLight.color = Color.red;
        }
        BCP.CheckRequirements();
        //if (BCP.CheckRequirements())
        //    BCP.Dissappear();
    }

}
