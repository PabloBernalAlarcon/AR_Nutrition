using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialPanel : MonoBehaviour {

	public void ChangeAnimState(bool _state)
    {
        GetComponent<Animator>().SetBool("Show",_state);
    }
}
