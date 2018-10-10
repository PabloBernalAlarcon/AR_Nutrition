using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour {

    Dictionary<string, List<GameObject>> BackPack;
    public int[] CurrentObjects;
    private void Start()
    {
        BackPack = new Dictionary<string, List<GameObject>>();
        CurrentObjects = new int[5];
        for (int i = 0; i < CurrentObjects.Length; i++)
        {
            CurrentObjects[i] = 0;
        }
         
    }

    public void AddItemToBackPack(GameObject toAdd)
    {
        //check for nullness
        if (BackPack == null)
        {
            print("There's no bag.");
            return;
        }
        else if(toAdd == null)
        {
            print("The item is null");
            return;
        }

        //create category if it's nonexistent
        if (BackPack.ContainsKey(toAdd.tag))
        {
            if (BackPack[toAdd.tag] == null)
            {
                BackPack.Add(toAdd.tag, new List<GameObject>());
                BackPack[toAdd.tag].Add(toAdd);
            }
            else
                 BackPack[toAdd.tag].Add(toAdd);
            
        }
        else
        {
            BackPack.Add(toAdd.tag, new List<GameObject>());
            BackPack[toAdd.tag].Add(toAdd);
        }
    }

    public void RemoveItemFromBackPack(GameObject toRemove)
    {

        //check for nullness
        if (BackPack == null)
        {
            print("There's no bag.");
            return;
        }
        else if (toRemove == null)
        {
            print("The item is null");
            return;
        }
        //if the category does not exist
        if (BackPack[toRemove.tag] != null)
        {
            BackPack[toRemove.tag].Remove(toRemove);
        }
    }

    public void PrintBackPackElements(Text t)
    {
        for (int i = 0; i < CurrentObjects.Length; i++)
        {
            CurrentObjects[i] = 0;
        }
        t.text = string.Empty;
        t.text += "The list has: \n";
        foreach (KeyValuePair<string,List<GameObject>> item in BackPack)
        {
            Utility.FoodType fd= (Utility.FoodType)System.Enum.Parse(typeof(Utility.FoodType), item.Key);
            //CurrentObjects[(int)fd] = 1;
            //CurrentObjects[];
            t.text += item.Key.ToUpper()+": \n";
            for (int i = 0; i < item.Value.Count; i++)
            {
                t.text += item.Value[i].name + "\n";
                CurrentObjects[(int)fd]++;
            }
        }

        EventManager.TriggerEvent("Compare");
    }
}
