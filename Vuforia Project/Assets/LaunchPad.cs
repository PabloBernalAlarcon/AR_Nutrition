using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPad : MonoBehaviour {

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
        anim.SetBool("Emerge", true);
    }

    public void Hide()
    {
        anim.SetTrigger("Pressed");
    }
}
