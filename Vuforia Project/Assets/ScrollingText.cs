using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScrollingText : MonoBehaviour {

    Animator anim;
    Text t;
    private void Start()
    {
        anim = GetComponent<Animator>();
        t = GetComponent<Text>();
    }

    public void UpdateText(string newText)
    {
        StartCoroutine(UpdateT(newText));
    }

    IEnumerator UpdateT(string newText)
    {
        yield return null; //WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).length >= 1);
        t.text = newText;
        
    }
}
