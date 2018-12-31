using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadingCurtain : MonoBehaviour {


    //public members
   public bool CurtainIsBlack;
    //private members
    Image blackCourtain;
    bool bringCourtain;
    

    //private but serialized
    [SerializeField]
    LoadingScenesComponent LSC;
    [SerializeField]
    bool ThisIsTheLoadingScene;

    private void Start()
    {
        if (ThisIsTheLoadingScene)
            LSC.LoadSceneOnBackground(this);
    }

    // Use this for initialization
    void Awake () {
        blackCourtain = GetComponent<Image>();
	}

    private void OnEnable()
    {
        if (bringCourtain)
            FadeIn();
        else
            FadeOut();
    }

    private void OnDisable()
    {
        bringCourtain = true;
    }


    public void FadeOut()
    {
        StartCoroutine(FadeO());
    }

    IEnumerator FadeO()
    {
        Color tempColor = blackCourtain.color;
        for (float i = 1f; i >= 0f; i -= Time.deltaTime/3)
        {
            tempColor.a = i;
            blackCourtain.color = tempColor;
            yield return null;
        }

        if (!ThisIsTheLoadingScene)
            gameObject.SetActive(false);
        else
        {
            yield return new WaitForSeconds(1);
            FadeIn();
        }
    }

     void FadeIn()
    {
        StartCoroutine(FadeI());
    }

    IEnumerator FadeI()
    {
        //load scene asyncronously, triger load when the sreen is black
        if(!ThisIsTheLoadingScene)
         LSC.LoadSceneOnBackground(this);

        Color tempColor = blackCourtain.color;
        for (float i = 0f; i <= 1f; i += Time.deltaTime/3)
        {
            tempColor.a = i;
            blackCourtain.color = tempColor;
            yield return null;
        }
        CurtainIsBlack = true;
    }
}
