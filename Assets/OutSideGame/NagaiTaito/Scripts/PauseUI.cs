using DG.Tweening;
using UnityEngine;

public class PauseUI : MonoBehaviour
{
    [SerializeField] Animator _pauseAnimator = default;
    PauseManager _pauseManager = default;

    private void Awake()
    {
        _pauseManager = GameObject.FindObjectOfType<PauseManager>();
    }
    private void OnEnable()
    {
        _pauseManager._pause += ShowPause;
    }
    private void OnDisable()
    {
        _pauseManager._pause -= ShowPause;
    }

    void ShowPause(bool isPause)
    {
        if(isPause)
        {
            _pauseAnimator.Play("Color");
        }
        else
        {
            _pauseAnimator.Play("Idol");
        }
    }
}
