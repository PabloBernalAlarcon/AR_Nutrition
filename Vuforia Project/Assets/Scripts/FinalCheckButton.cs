using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCheckButton : MonoBehaviour {

    public void Dissappear()
    {
        
        GetComponent<RectTransform>().position = new Vector3(99999, 9999999);
    }
   
    public void flip()
    {
        GetComponent<Animator>().SetTrigger("Shrink");
        if (GetComponent<AudioSource>())
            GetComponent<AudioSource>().Play();


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
