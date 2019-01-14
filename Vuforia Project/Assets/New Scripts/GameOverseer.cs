using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  class GameOverseer :MonoBehaviour {

    //*****PUBLIC MEMBERS*****

    //Singleton instence for the class
    public static GameOverseer instance;
    //delegate related to image targeting
    public delegate void AREvent(bool _trigger);
    //delegate related to game objective events
    public delegate void GameEvent();
    //event related to when the image target was found or lost
    public  event AREvent ARTargetFoundStatus;
    //event fired when the player checks any rocekt item
    public event GameEvent ItemsChecked;

    public enum Parts
    {
        Payload,
        Centaur,
        Thruster
    }

    //*****PRIVATE MEMBERS*****

    //List of elements affected by tracking
    private List<GameObject> UIElements;

    //numer of items that the player has to check
    int MaxObjectives = 3;

    //number of items the player has checked
    int CO =0;
    public int CurrentObjectves
    {
        get
        {
            return CO;
        }

        set
        {
            CO = value;
            if (CO >= MaxObjectives && ItemsChecked != null)
                ItemsChecked();
        }
    }

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
        {
            if ( item != null)
            {
                if (item.GetComponent<Image>())
                    item.GetComponent<Image>().enabled = _Active;
                else if (item.GetComponent<Text>())
                    item.GetComponent<Text>().enabled = _Active;
                else
                    item.SetActive(_Active);

            }
        }
            
                 
    }

    //found Image Target
    public void Found()
    {
        //Time.timeScale = 1;

        print("fond ye");

        ChangeUIElementsStatus(true);

        if(ARTargetFoundStatus!= null)
            ARTargetFoundStatus(true);
    }

    //Lost Image Target
    public void Lost()
    {
       // Time.timeScale = 0;

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
        CO = 0;
    }

    //Adds a element to the list. to be called from other scripts on awake awake.
    public void AddUIItem(GameObject UIitem)
    {
        UIElements.Add(UIitem);
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
    }

}


