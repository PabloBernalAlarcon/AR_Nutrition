using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldUIBubble : MonoBehaviour {

    [SerializeField]
    Transform cam;

    Animator Anim;
    private void OnEnable()
    {
        GameOverseer.instance.ItemsChecked += KillCanvas;
    }
    private void OnDisable()
    {
        GameOverseer.instance.ItemsChecked -= KillCanvas;
    }


    private void Start()
    {
        Anim = GetComponentInChildren<Animator>();
    }

    void KillCanvas()
    {
        GetComponent<CanvasGroup>().interactable = false;
        Anim.Play("Shrink");
    }
    // Update is called once per frame
    void Update () {

        Vector3 targetPostition = new Vector3(-cam.position.x,
                                       this.transform.position.y,
                                       -cam.position.z);
        this.transform.LookAt(targetPostition);
	}
}
