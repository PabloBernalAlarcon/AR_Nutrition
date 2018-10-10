using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField]
    Player player;
    [SerializeField]
    ObjectiveManager objectiveManager;

    int[] Objective;
    int[] Current;
    private void OnEnable()
    {
        EventManager.StartListening("Compare", CompareItems);
    }
    private void OnDisable()
    {
        EventManager.StopListening("Compare", CompareItems);
    }
    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CompareItems()
    {
        Objective = objectiveManager.HowMany;
        Current = player.CurrentObjects;

        if (Current.SequenceEqual(Objective))
        {
            print("ya got it mate");
        }
        else
            print("yer gettin close");
        
    }
}
