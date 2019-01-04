using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class GameOverseer :MonoBehaviour {

    //*****PUBLIC MEMBERS*****

    //Singleton instence for the class
    public static GameOverseer instance;
    //delegate related to image targeting
    public delegate void AREvent(bool _trigger);
    //event related to when the image target was found or lost
    public  event AREvent ARTargetFoundStatus;

    public enum Parts
    {
        Payload,
        Centaur,
        Thruster
    }

    //*****PRIVATE MEMBERS*****

    //List of elements affected by tracking
    private List<GameObject> UIElements;

    //*****METHODS*****

    private void Awake()
    {
        
        //Do I exist?
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this);

        UIElements = new List<GameObject>();
    }

    //Changes the status (active/not) of the UIElement's items
    private void ChangeUIElementsStatus(bool _Active)
    {
        foreach (GameObject item in UIElements)
            item.SetActive(_Active);       
    }

    //found Image Target
    public void Found()
    {
        Time.timeScale = 1;

        print("fond ye");

        ChangeUIElementsStatus(true);

        if(ARTargetFoundStatus!= null)
            ARTargetFoundStatus(true);
    }

    //Lost Image Target
    public void Lost()
    {
        Time.timeScale = 0;

        print("You lost me babe");

        ChangeUIElementsStatus(false);

        if(ARTargetFoundStatus != null)
            ARTargetFoundStatus(false);
    }

    //Clear List elements -- use every time
    //the scene is changed since this is script is not deleted.
    public void ResetList()
    {
        UIElements.Clear();
    }

    //Adds a element to the list. to be called from other scripts on awake awake.
    public void AddUIItem(GameObject UIitem)
    {
        UIElements.Add(UIitem);
    }

}
