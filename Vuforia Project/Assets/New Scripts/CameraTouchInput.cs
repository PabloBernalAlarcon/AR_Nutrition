using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CameraTouchInput : MonoBehaviour {

    [SerializeField]
    Text t;

    public delegate void Click();
    public static event Click ClickedItem;


    AudioSource AS;
    private void OnEnable()
    {
        GameOverseer.instance.ARTargetFoundStatus += HandlePause;
    }
    private void OnDisable()
    {
        GameOverseer.instance.ARTargetFoundStatus -= HandlePause;
    }

    private void Start()
    {
        AS = GetComponent<AudioSource>();
        AS.Pause();
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit))
            {
                if (hit.transform.name == "Atlas_5_Mesh")
                    if (ClickedItem != null)
                        ClickedItem();
            }
        }
	}

    void HandlePause(bool _paused)
    {
        if (!_paused)
            AS.Pause();
        else
            AS.UnPause();
    }
}
