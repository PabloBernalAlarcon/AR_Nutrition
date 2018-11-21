using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControlPanel : MonoBehaviour {

    public LightSwitch[] Switches;
	
    public bool CheckRequirements()
    {
        int x = 0;
        for (int i = 0; i < Switches.Length; i++)
        {
            if (Switches[i].LightOn)
            {
                x++;
            }
        }

        if (x == Switches.Length)
        {
           // GetComponent<AudioSource>().Play();
            StartCoroutine(Lol());
            return true;
        }

        return false;
    }

    public void Dissappear()
    {
        StartCoroutine(Lol());
    }

    IEnumerator Lol()
    {
        // yield return new WaitUntil(() => !GetComponent<AudioSource>().isPlaying);
        yield return null;
        GetComponent<Animator>().SetTrigger("Shrink");
    }
}
