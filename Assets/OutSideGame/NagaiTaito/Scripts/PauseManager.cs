using System;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    bool _pauseJudge = false;
    public event Action<bool> _pause;

    public void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            PauseResume();
        }
    }

    void PauseResume()
    {
        _pauseJudge = !_pauseJudge;
        _pause(_pauseJudge);
    }
}
