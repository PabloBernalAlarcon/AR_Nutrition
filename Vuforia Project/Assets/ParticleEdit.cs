using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEdit : MonoBehaviour {

    ParticleSystem PS;
	// Use this for initialization
	void Start () {
        PS = GetComponent<ParticleSystem>();
	}

    private void OnEnable()
    {
        UberRocket.fadeOut += ChangeParticleAngle;
    }
    private void OnDisable()
    {
        UberRocket.fadeOut -= ChangeParticleAngle;
    }

    void ChangeParticleAngle()
    {
        StartCoroutine(ChangeParticleAngleCor());
    }

	IEnumerator ChangeParticleAngleCor()
    {
        var shkere = PS.shape;

        for (float i = 90; i >= 10; i-= (Time.deltaTime *9))
        {
            shkere.angle = i;
        yield return null;
        }
    }
}
