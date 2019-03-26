using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPiece : MonoBehaviour {

    [HideInInspector]
    public ParticleSystem PS;
    bool detahed;
    AudioSource AS;
    Vector3 rotat;
    private void OnEnable()
    {
        GameOverseer.instance.ARTargetFoundStatus += HandlePause;
    }
    private void OnDisable()
    {
        GameOverseer.instance.ARTargetFoundStatus -= HandlePause;
    }

    bool pause;
    void HandlePause(bool _resume)
    {
        pause = !_resume;
    }
    // Use this for initialization
    void Awake () {
        PS = GetComponent<ParticleSystem>();
        AS = GetComponent<AudioSource>();
        rotat = new Vector3();
        for (int i = 0; i < 3; i++)
        {
            rotat[i] = Random.Range(0f, 20);
        }
	}

    private void FixedUpdate()
    {
        if (detahed)
        {
            transform.Rotate(rotat*Time.deltaTime);
        }
    }
    public void DetachPiece(ParticleSystem _ps)
    {
        StartCoroutine(detach(_ps));
    }

    IEnumerator detach(ParticleSystem _ps)
    {
       var par = PS.main;
        par.loop = false;
       // PS.Stop();
        yield return new WaitForSeconds(3);
        yield return new WaitUntil(() => !pause);
        AS.Play();
        Handheld.Vibrate();
        transform.parent = null;
        detahed = true;
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => !pause);
        _ps.Play();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
