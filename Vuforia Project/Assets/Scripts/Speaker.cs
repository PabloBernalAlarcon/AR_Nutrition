using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Speaker : MonoBehaviour {

    public GameObject Blocker;

    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(SpeakPlease(GetComponent<AudioSource>()));
        }
        else if(Input.GetKey(KeyCode.W))
            StartCoroutine(SpeakPlease(GetComponent<AudioSource>(),false));
    }

   public IEnumerator SpeakPlease(AudioSource AS,bool blockPlayer = true)
    {
      

        AS.Play();
        if(blockPlayer)
            Blocker.SetActive(true);
        anim.Play("Speak");
        yield return new WaitUntil(() => !AS.isPlaying);
        anim.Play("Idle");
        Blocker.SetActive(false);
    }
   
    public IEnumerator SpeakLaunch(bool blockPlayer = true)
    {
       
        if (blockPlayer)
            Blocker.SetActive(true);
        anim.Play("Speak");
        yield return new WaitForSeconds(13);
        anim.Play("Idle");
        Blocker.SetActive(false);
    }
}
