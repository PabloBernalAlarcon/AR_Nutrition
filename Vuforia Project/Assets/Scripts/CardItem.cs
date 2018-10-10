using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardItem : MonoBehaviour {

    [SerializeField]
    Utility.FoodType FType;
    public string FoodName; //{ get { return FoodName; } }
    public bool visited;// { get { return visited; } }
    // Use this for initialization
    private void Start()
    {
        gameObject.tag = FType.ToString();
    }

}
