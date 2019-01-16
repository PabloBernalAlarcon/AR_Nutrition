using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : MonoBehaviour {

  
    [SerializeField]
    UberRocket Rocke;

    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    private void OnEnable()
    {
        GameOverseer.instance.ItemsChecked += Emerge;
    }

    private void OnDisable()
    {
        GameOverseer.instance.ItemsChecked += Emerge;
    }

    void Emerge()
    {
            if(anim != null)
             anim.SetBool("Emerge", true);
        else
        print("NO ANIMATOR FOR SOME STUPID REASON");
    }

    public void Hide()
    {
        anim.SetTrigger("Pressed");
    }

    public void Launch()
    {
        Rocke.StartLaunchSequence();
    }
}
