using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollAnimations : MonoBehaviour {
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	public void SetState(int Size)
    {
         anim.SetInteger("size", Size);
        
    }
}
