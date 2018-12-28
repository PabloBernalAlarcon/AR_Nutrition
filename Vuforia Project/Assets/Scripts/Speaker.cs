using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Speaker : MonoBehaviour {

    public GameObject Blocker;
    Image img;
    Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        img = GetComponent<Image>();
        img.color = new Color(img.color.r, img.color.g, img.color.b, 0);
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

        img.color = new Color(img.color.r, img.color.g, img.color.b, 1);
        AS.Play();
        if(blockPlayer)
            Blocker.SetActive(true);
        anim.Play("Speak");
        yield return new WaitUntil(() => !AS.isPlaying);
        anim.Play("Idle");
        img.color = new Color(img.color.r, img.color.g, img.color.b, 0);
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
