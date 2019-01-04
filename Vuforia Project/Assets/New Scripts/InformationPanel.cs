using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InformationPanel : MonoBehaviour {

    [SerializeField]
    Text PartName;
    [SerializeField]
    Text PartInfo;
    [SerializeField]
    Image PartImage;

    Animator Anim;
    private void Start()
    {
        Anim = GetComponent<Animator>();
      
    }


    public void ChangeData(PanelInfo _Pi)
    {
        PartName.text = _Pi.PartName;
        PartInfo.text = _Pi.PartDescription;
        PartImage.sprite = _Pi.PartImage;
        Anim.SetTrigger("Grow");
    }

    public void CloseTab()
    {
        Anim.SetTrigger("Shrink");
    }
}
