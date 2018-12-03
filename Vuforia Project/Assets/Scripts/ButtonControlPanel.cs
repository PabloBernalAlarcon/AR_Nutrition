using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControlPanel : MonoBehaviour {

    public LightSwitch[] Switches;
    public FinalCheckButton FBC;
    public bool CheckRequirements()
    {
        int x = 0;
        for (int i = 0; i < Switches.Length; i++)
        {
            if (Switches[i].LightOn)
            {
                x++;
            }
        }

        if (x == Switches.Length)
        {
            //  FBC.Dissappear();
            FBC.flip();
            return true;
        }

        return false;
    }

   

}
