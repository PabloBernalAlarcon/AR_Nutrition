using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStuff : MonoBehaviour {
    Speaker speak;
    AudioSource AS;
	// Use this for initialization
	void Start () {
        speak = GameObject.FindGameObjectWithTag("Speaker").GetComponent<Speaker>();
        AS = GetComponent<AudioSource>();
	}
	
	public void TriggerSpeaker(bool block = true)
    {
        if (AS)
            StartCoroutine(speak.SpeakPlease(AS, block));
        else
            StartCoroutine(speak.SpeakLaunch());
    }
}
