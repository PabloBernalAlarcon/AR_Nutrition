using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCheckButton : MonoBehaviour {

    public void Dissappear()
    {
        GetComponent<Animator>().SetTrigger("Shrink");

    }
   


    public void DissappearSound()
    {
       
        StartCoroutine( bye());
    }
    [SerializeField]
    GameObject CPCover;
    IEnumerator bye()
    {
       
            GetComponent<AudioSource>().Play();
            yield return new WaitUntil(() => !GetComponent<AudioSource>().isPlaying);

        
      
            CPCover.GetComponent<Animator>().SetTrigger("Shrink");
    }
}
