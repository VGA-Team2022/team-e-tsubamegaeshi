using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator _playerAnimator = default;
    float _playerAnimSpeed = 0f;
    [SerializeField] Animator _enemyAnimator = default;
    float _enemyAnimSpeed = 0f;
    [SerializeField] Animator _playerTransform = default;
    float _playerTransformSpeed = 0f;
    [SerializeField] Animator _enemyTransform = default;
    float _enemyTransformSpeed = 0f;
    PauseManager _pauseManager = default;

    private void Awake()
    {
        _pauseManager = FindObjectOfType<PauseManager>();
    }
    void OnEnable()
    {
        _pauseManager._pause += PauseResume;
    }
    void OnDisable()
    {
        _pauseManager._pause -= PauseResume;
    }
    void PauseResume(bool isPause)
    {
        if (isPause)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }

    public void Pause()
    {
        
        _playerAnimSpeed = _playerAnimator.speed;
        _playerAnimator.speed = 0;
        _playerTransformSpeed = _playerTransform.speed;
        _playerTransform.speed = 0;
        _enemyAnimSpeed = _enemyAnimator.speed;
        _enemyAnimator.speed = 0;
        _enemyTransformSpeed = _enemyTransform.speed;
        _enemyTransform.speed = 0;
    }
    public void Resume()
    {
        _playerAnimator.speed = _playerAnimSpeed;
        _playerTransform.speed = _playerTransformSpeed;
        _enemyAnimator.speed = _enemyAnimSpeed;
        _enemyTransform.speed = _enemyTransformSpeed;
    }
}
