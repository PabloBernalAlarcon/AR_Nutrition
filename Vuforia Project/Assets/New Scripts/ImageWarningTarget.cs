using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ImageWarningTarget : MonoBehaviour {

    private void OnEnable()
    {
        GameOverseer.instance.ARTargetFoundStatus += TriggerStatus;
    }

    private void OnDisable()
    {
        GameOverseer.instance.ARTargetFoundStatus -= TriggerStatus;
    }


    void TriggerStatus(bool Trigger)
    {
        GetComponent<Image>().enabled = !Trigger;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(!Trigger);
        }
    }
}
