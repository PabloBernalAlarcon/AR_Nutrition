using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class GameOverseer :MonoBehaviour {

    //Singleton instence for the class
    public static GameOverseer instance;

    public delegate void AREvent(bool _trigger);

    public  event AREvent ARTargetFoundStatus;

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
    }

    public void Found()
    {
        //base.OnTrackingFound();
        print("fond ye");

        if(ARTargetFoundStatus!= null)
            ARTargetFoundStatus(true);
    }

    public void Lost()
    {
       // base.OnTrackingLost();
        print("You lost me babe");
        if(ARTargetFoundStatus != null)
            ARTargetFoundStatus(false);
    }
}
