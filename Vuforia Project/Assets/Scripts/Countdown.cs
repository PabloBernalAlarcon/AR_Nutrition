using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Countdown : MonoBehaviour {

    Text t;
    Animator anim;
    AudioSource AS;
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
    IEnumerator StartCountdown(int number = 3)
    {
        for (int i = 0; i < number; i++)
        {
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
