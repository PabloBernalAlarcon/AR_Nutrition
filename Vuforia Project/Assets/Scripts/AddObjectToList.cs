using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AddObjectToList : MonoBehaviour {

    int index = 0;
    public GameObject ItemTemplate;
    public GameObject Content;

    public void AddButton_Click(CardItem info)
    {
        GameObject copy = Instantiate(ItemTemplate);
        copy.transform.SetParent(Content.transform);
        copy.GetComponentInChildren<Text>().text = info.name;
        copy.GetComponent<Image>().color = info.color;
        copy.transform.localScale = Vector3.one;
        int copyofindex = index;
        copy.GetComponent<Button>().onClick.AddListener(
            () =>
            {
                Debug.Log("Index number: " + copyofindex);
            }
            );
        index++;

    }
}
