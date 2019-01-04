using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PanelInfo : MonoBehaviour {

    [SerializeField]
    public string PartName;

    [SerializeField]
    public Sprite PartImage;

    [SerializeField]
    public string PartDescription;

    [SerializeField]
    public GameOverseer.Parts PartType;


    public void Init( string _partName,
        Sprite _PartImage,
        string _PartDescription,
        GameOverseer.Parts _PartType)
    {

        PartName = _partName;
        PartImage = _PartImage;
        PartDescription = _PartDescription;
        PartType = _PartType;
    }
}
