using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSwitcher : MonoBehaviour {

    [SerializeField]
    GameObject RegularCanvas;
    [SerializeField]
    GameObject PhotoCanvas;

    bool RegularisUp {
        get
        {
            return RegularisUp;
        }
        set
        {
            RegularCanvas.SetActive(value);
            PhotoCanvas.SetActive(!value);
        }
    }
    private void Start()
    {
        RegularisUp = true;
    }

    public void ToggleCanvases()
    {
        RegularisUp = !RegularisUp;
    }
 }
