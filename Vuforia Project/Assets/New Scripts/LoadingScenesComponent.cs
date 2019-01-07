using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadingScenesComponent : MonoBehaviour {

    [SerializeField]
    string SceneToLoad;

    bool AlreadyLoading;

    public void LoadScene(string _Name)
    {
        SceneManager.LoadScene(_Name);
    }

    public void LoadSceneOnBackground(FadingCurtain TriggerLoad)
    {
        StartCoroutine(LoadAsy( TriggerLoad));
    }
    IEnumerator LoadAsy( FadingCurtain TriggerLoad)
    {

        TriggerLoad.gameObject.SetActive(true);
        if (AlreadyLoading)
            yield break;
        AlreadyLoading = true;
        //Begin to load the Scene you specify
        AsyncOperation asyncOperation;
        if (SceneToLoad != "")
            asyncOperation = SceneManager.LoadSceneAsync(SceneToLoad);
        else
            yield break;
        //Don't let the Scene activate until you allow it to
        asyncOperation.allowSceneActivation = false;
       
        while (!asyncOperation.isDone)
        {
            print(asyncOperation.progress);

            // Check if the load has finished
            if (asyncOperation.progress >= 0.9f)
            {
             
                yield return new WaitUntil(() => TriggerLoad.CurtainIsBlack);
                asyncOperation.allowSceneActivation = true;
               
               
            }

            yield return null;
        }
        
    }
}
