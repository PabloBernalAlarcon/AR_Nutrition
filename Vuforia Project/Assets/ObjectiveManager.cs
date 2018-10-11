using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour {

    Utility.FoodType foodType;
    //in case I forget: there's 5 elements, one for each food group present.
    //a value of 0 means that food group is not required.
    //a value between 1 and 5 means that that should be the total collected items of that specific group.
    private int[] howMany = new int[5];
    [SerializeField]
    AddObjectToList ListAdder;

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

    private void Start()
    {
        PopulateObjective();
    }
    void PopulateObjective()
    {
        for (int i = 0; i < howMany.Length; i++)
        {
            if(howMany[i] != 0)
            {
                CardItem CI = new GameObject(((Utility.FoodType)i).ToString()).AddComponent<CardItem>();
               
                CI.Setup((Utility.FoodType)i, ((Utility.FoodType)i).ToString(),Utility.FoodColor[i]);
                ListAdder.AddButton_Click(CI);
            }

        }
        
    }
}
