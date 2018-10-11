using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardItem : MonoBehaviour {

    [SerializeField]
    Utility.FoodType FType;
    public string FoodName; //{ get { return FoodName; } }
    public bool visited;// { get { return visited; } }
    public Color color;

    // Use this for initialization
    private void Start()
    {
        gameObject.tag = FType.ToString();
    }

    public void Setup(Utility.FoodType FoodT, string _FoodName, Color c)
    {
        FType = FoodT;
        FoodName = _FoodName;
        color = c;
        visited = false;
    }

}
