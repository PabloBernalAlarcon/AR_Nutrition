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

    private void OnEnable()
    {
        if(Anim != null)
        Anim.SetBool("Show", state);
    }
    private void Start()
    {
        Anim = GetComponent<Animator>();  
      
    }

    bool state;

    public void ChangeData(PanelInfo _Pi)
    {
        PartName.text = _Pi.PartName;
        PartInfo.text = _Pi.PartDescription;
        PartImage.sprite = _Pi.PartImage;
        part = _Pi.PartType;
        Anim.SetBool("Show", true);
        state = true;
    }

    public void CloseTab()
    {
        Anim.SetBool("Show", false);
        Infoes[(int)part].CompletedCheck();
        state = false;
    }
}
