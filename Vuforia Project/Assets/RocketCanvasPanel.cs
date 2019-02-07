using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RocketCanvasPanel : MonoBehaviour {

    List<Button> Buttons;
    [SerializeField]
    Button TakePhoto;
	// Use this for initialization
	void Start () {
        Buttons = new List<Button>();

        for (int i = 0; i <transform.childCount; i++)
        {
            Buttons.Add(transform.GetChild(i).GetComponent<Button>());
        }
        Buttons.Add(TakePhoto);
	}
	
	public void SetButtonsState(bool _active)
    {
        for (int i = 0; i < Buttons.Count; i++)
        {
            Buttons[i].interactable = _active;
        }
    }
}
