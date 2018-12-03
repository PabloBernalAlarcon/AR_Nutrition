using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour {

   
    public Slider slide;
    AsyncOperation async;


    private void Start()
    {
        LoadStuff();
    }
    void LoadStuff()
    {
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        async = SceneManager.LoadSceneAsync("RocketScene");
        async.allowSceneActivation = false;

        while (!async.isDone)
        {
            slide.value = async.progress;
            if (async.progress >= 0.9f)
            {
                slide.value = 1f;
                async.allowSceneActivation = true;
            }

            yield return null;
        }
    }


}
