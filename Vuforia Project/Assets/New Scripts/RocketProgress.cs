using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RocketProgress : MonoBehaviour {

    [SerializeField]
    CPC_CameraPath Camerapath;
    [SerializeField]
    GameObject TapRocketImage;
    Slider slider;

    Animator anim;

    bool alertIsGoing;

    private void OnEnable()
    {
        UberRocket.Allowdeployment += AlertPlayer;
        if (alertIsGoing)
        {
            anim.SetBool("Bounce", true);
            GetComponent<AudioSource>().Play();
        }
    }

    private void OnDisable()
    {
        UberRocket.Allowdeployment -= AlertPlayer;
    }

    // Use this for initialization
    void Start () {
        slider = GetComponent<Slider>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        slider.value = Camerapath.ProgressPercentage;
	}

    
    public void AlertPlayer(bool _activate)
    {
        alertIsGoing = _activate;

        if (_activate)
            GetComponent<AudioSource>().Play();
        else
            GetComponent<AudioSource>().Stop();

        TapRocketImage.SetActive(_activate);
        anim.SetBool("Bounce", _activate);
    }

    

   
}
