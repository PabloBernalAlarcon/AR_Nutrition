using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Countdown : MonoBehaviour {

    Text t;
    Animator anim;
    AudioSource AS;

    private void OnEnable()
    {
        GameOverseer.instance.ARTargetFoundStatus += HandlePause;
    }
    private void OnDisable()
    {
        GameOverseer.instance.ARTargetFoundStatus -= HandlePause;
    }
    // Use this for initialization
    void Start () {
        t = GetComponent<Text>();
        anim = GetComponent<Animator>();
        AS = GetComponent<AudioSource>();
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(StartCountdown());
        }
    }
    public void StartCounting(int number = 3)
    {
        StartCoroutine(StartCountdown( number));
    }

    bool paused;

    void HandlePause(bool _paused)
    {
        paused = _paused;
    }
    IEnumerator StartCountdown(int number = 3)
    {
        for (int i = 0; i < number; i++)
        {
            yield return new WaitUntil(() => paused);

            if (number -i <= 3)
                t.color = Color.red;
            AS.Play();
            t.text = (number - i).ToString();
        anim.Play("count");
            yield return new WaitForSeconds(1);
        }
        t.color = Color.black;
        yield return null;
    }
}
