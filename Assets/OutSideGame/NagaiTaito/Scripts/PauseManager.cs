using System;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    bool _pauseJudge = false;
    public event Action<bool> _pause;

    public void Pause()
    {
        PauseResume();
    }

    void PauseResume()
    {
        _pauseJudge = !_pauseJudge;
        _pause(_pauseJudge);
    }
}
