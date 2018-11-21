using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FadeEffect : MonoBehaviour {
    [SerializeField]
    int SceneToLoad;
    Image SR;
    // Use this for initialization
    void Start()
    {
        SR = GetComponent<Image>();
       // StartCoroutine(FadeOut());
    }
    public void StartFadeIn(int Scene)
    {
        StartCoroutine(FadeIn(Scene));
    }
   public void StartFadeOut()
    {
        StartCoroutine(FadeOut());
    }
   public IEnumerator FadeOut()
    {

        Color c = SR.GetComponent<SpriteRenderer>().color;

        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            c.a = i;
            SR.GetComponent<SpriteRenderer>().color = c;
            yield return null;
        }
    }
   public IEnumerator FadeIn(int x = -1)
    {
        GetComponent<Image>().enabled = true;
        if (x == -1)
            x = SceneToLoad;
        Color c = SR.color;

        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            // set color with i as alpha
            c.a = i;
            SR.color = c;
            yield return null;
        }

      //  SceneManager.LoadScene(x);
    }
}
