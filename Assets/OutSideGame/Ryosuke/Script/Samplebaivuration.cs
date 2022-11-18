using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Samplebaivuration : MonoBehaviour
{
    public void OnVibration()
    {
        if(SystemInfo.supportsVibration)
        {
            Handheld.Vibrate();
        }
        else
        {
            Debug.Log("ƒoƒCƒu”ñ‘Î‰ž");
        }
    }
}
