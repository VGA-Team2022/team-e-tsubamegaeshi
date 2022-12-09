using UnityEngine;

public class PauseUI : MonoBehaviour
{
    [SerializeField] Animator _pauseAnimator = default;
    PauseManager _pauseManager = default;
    [SerializeField]  bool _panel = false;
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
            //_panel = true;
            Debug.Log("パネルあり");
            _pauseAnimator.Play("Pause");
        }
        else
        {
            //_panel = false;
            Debug.Log("パネルなし");
            _pauseAnimator.Play("Idol");
        }
    }
}
