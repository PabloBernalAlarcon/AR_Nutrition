using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneStuff : MonoBehaviour {

    public void SceneLoad(int s)
    {
        SceneManager.LoadScene(s);
    }
}
