using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFader : MonoBehaviour {

    AudioSource AS;
	// Use this for initialization
	void Start () {
        AS = GetComponent<AudioSource>();
	}
	
	public void ReduceVolume()
    {
        StartCoroutine(reduce());
    }

    IEnumerator reduce()
    {
        for (float i = 1f; i >= 0f; i-= Time.deltaTime/2)
        {
            AS.volume = i;
            yield return null;
        }
    }
}
