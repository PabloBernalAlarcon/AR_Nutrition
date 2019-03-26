using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GrowAndBye : MonoBehaviour {

    RectTransform trans;
    Image im;
    public bool Grow;
	// Use this for initialization
	void Start () {
        trans = GetComponent<RectTransform>();
        im = GetComponent<Image>();
	}

    private void OnEnable()
    {
        Rocket.fadeOut += shrek2;
    }
    private void OnDisable()
    {
        Rocket.fadeOut -= shrek2;
    }

  

    void shrek2()
    {
        StartCoroutine(FadeOutDie());
    }
    IEnumerator FadeOutDie()
    {
        if (Grow)
        {
            Color c = im.GetComponent<Image>().color;

            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                trans.localScale += new Vector3(Time.deltaTime, Time.deltaTime, 0); //new Vector3(1 - i, 1 - i, 0);
                // set color with i as alpha
                c.a = i;
                im.GetComponent<Image>().color = c;
                yield return null;
            }
        }
        else
        {
            if (GetComponent<Animator>())
                GetComponent<Animator>().enabled = false;
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                if (trans.localScale == Vector3.zero)
                    continue;
                trans.localScale -= new Vector3(Time.deltaTime, Time.deltaTime, 0);// new Vector3(1 - i, 1 - i, 0);
                if (trans.localScale.x < 0)
                {
                    trans.localScale = Vector3.zero;
                }
                // set color with i as alpha
               
                yield return null;
            }
            gameObject.SetActive(false);
        }
    }
}
