using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Utility{

    public enum FoodType { Fruit, Vegetable, Protein, Grain, Dairy};
    public static Color[] FoodColor = {
        Color.red,
        Color.green,
        new Color(0.8114f,0,1,1),
        new Color(1,0.5882f,0,1),
        new Color(0,0.6352f,0.9098f,1)};
}
