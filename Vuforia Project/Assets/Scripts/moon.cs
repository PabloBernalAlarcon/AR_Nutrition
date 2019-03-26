using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moon : MonoBehaviour {

    [SerializeField]
    Transform cam;
	[SerializeField]
    FadeEffect GoalImage;
	// Update is called once per frame
	void FixedUpdate () {
        transform.LookAt(cam);
	}

    private void OnCollisionEnter(Collision collision)
    {
        GoalImage.gameObject.SetActive(true);
        GoalImage.FadeIn();
    }

    private void OnTriggerEnter(Collider other)
    {
        GoalImage.gameObject.SetActive(true);
        GoalImage.StartFadeIn(0);
    }
}
