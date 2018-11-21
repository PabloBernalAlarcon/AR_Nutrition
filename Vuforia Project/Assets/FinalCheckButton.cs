using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCheckButton : MonoBehaviour {

    public void Dissappear()
    {
        StartCoroutine(Lol());
    }

    IEnumerator Lol()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitUntil(() => !GetComponent<AudioSource>().isPlaying);
        GetComponent<Animator>().SetTrigger("Shrink");
    }
}
