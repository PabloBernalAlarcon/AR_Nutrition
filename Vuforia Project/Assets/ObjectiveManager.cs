using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour {

    Utility.FoodType foodType;
    //in case I forget: there's 5 elements, one for each food group present.
    //a value of 0 means that food group is not required.
    //a value between 1 and 5 means that that should be the total collected items of that specific group.
    private int[] howMany = new int[5];

    public int[] HowMany
    {
        get
        {
            return howMany;
        }
    }

    // Use this for initialization
    void Awake () {
        for (int i = 0; i < HowMany.Length; i++)
        {
            HowMany[i] = Random.Range(0, 2);
           
        }
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
