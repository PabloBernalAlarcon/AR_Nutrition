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
    [SerializeField]
    PanelInfo[] Infoes;
    
    Animator Anim;
    GameOverseer.Parts part;
    private void Start()
    {
        Anim = GetComponent<Animator>();
      
    }


    public void ChangeData(PanelInfo _Pi)
    {
        PartName.text = _Pi.PartName;
        PartInfo.text = _Pi.PartDescription;
        PartImage.sprite = _Pi.PartImage;
        part = _Pi.PartType;
        Anim.SetTrigger("Grow");
    }

    public void CloseTab()
    {
        Anim.SetTrigger("Shrink");
        Infoes[(int)part].CompletedCheck();
        
    }
}
