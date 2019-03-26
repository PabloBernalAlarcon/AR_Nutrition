using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour {

   
    public Slider slide;
    AsyncOperation async;
    public Transform Target;
    public Transform rocket;
    Vector3 initpos;
    float delta;
    private void Start()
    {
        LoadStuff();
        initpos = rocket.position;
       // delta = Target.position.y - rocket.position.y;
    }
    void LoadStuff()
    {
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        async = SceneManager.LoadSceneAsync("old RocketScene");
        async.allowSceneActivation = false;

        while (!async.isDone)
        {
           // slide.value = async.progress;

            rocket.position = Vector3.Lerp(initpos, Target.position, async.progress);
            if (async.progress >= 0.9f)
            {
               // slide.value = 1f;
                async.allowSceneActivation = true;
            }

            yield return null;
        }
    }


}
