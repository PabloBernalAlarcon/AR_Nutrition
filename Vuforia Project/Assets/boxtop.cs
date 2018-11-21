using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxtop : MonoBehaviour {

    [SerializeField]
    GameObject f;

    bool faded;
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        if (!faded)
        {
            f.SetActive(true);
            if (f)
            {
                
                f.GetComponent<FadeEffect>().StartFadeIn(-1);
                faded = true;
            }
            else
                print("I see nithing");
        }
        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
