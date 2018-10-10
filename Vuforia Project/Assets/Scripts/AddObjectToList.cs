using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AddObjectToList : MonoBehaviour {

    int index = 0;
    public GameObject ItemTemplate;
    public GameObject Content;

    public void AddButton_Click()
    {
        GameObject copy = Instantiate(ItemTemplate);
        copy.transform.SetParent(Content.transform);
        copy.GetComponentInChildren<Text>().text = (index + 1).ToString();
        index++;

    }
}
