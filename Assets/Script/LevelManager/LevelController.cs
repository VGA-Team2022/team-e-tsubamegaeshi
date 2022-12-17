using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 難易度のState
/// </summary>
public enum LevelState
{
    EASY = 0, // 初級
    NORMAL = 1, // 中級
    HARD = 2, // 上級
    EXPART = 3, // 超上級
}

/// <summary>
/// 難易度に応じて、プレイヤーとエネミー
/// </summary>
public class LevelController : MonoBehaviour
{
    private static LevelController instance;
    public static LevelController Instance
    {
        get
        {
            if (instance == null)
            {
                var LevelControllerPrefab = Resources.Load<LevelController>("LevelManager");
                instance = Instantiate(LevelControllerPrefab);
                DontDestroyOnLoad(Instance);
            }

            return instance;
        }
    }

    [Header("-------------------難易度の設定・ステータスを設定------------------")]
    [Header("難易度"), SerializeField]
    private LevelState _levelState;

    [Header("プレイヤー用ステータス")]
    [SerializeField]
    private float _playerSpeed = 1;
    [SerializeField]
    private float _playerKnockbackDistance = 1f;
    [SerializeField]
    private float _playerKnockbackTime = 1f;
    [SerializeField]
    private float _playerAttackInterval = 1f;

    [Header("エネミー用ステータス")]
    [SerializeField]
    private float _enemySpeed = 1;
    [SerializeField]
    private float _enemyKnockbackDistance = 1f;
    [SerializeField]
    private float _enemyKnockbackTime = 1f;
    [SerializeField]
    private float _enemyStartPos = 0f;

    [Header("----------------------下記の項目は変更不可----------------------")]
    // プレイヤーのステータスを保存 
    // 1.Speed 2.KnockbackDistance 3.KnockbackTime 4.AttackInterval
    [Tooltip("Easy用プレイヤーStatus")]
    public float[] _easyPlayerStatus = new float[4];
    [Tooltip("Normal用プレイヤーStatus")]
    public float[] _normalPlayerStatus = new float[4];
    [Tooltip("Hard用プレイヤーStatus")]
    public float[] _hardPlayerStatus = new float[4];
    [Tooltip("EXPART用プレイヤーStatus")]
    public float[] _expartPlayerStatus = new float[4];

    // エネミーのステータスを保存
    // 1.Speed 2.KnockbackDistance 3.KnockbackTime 4.StartPosition
    [Tooltip("Easy用エネミーStatus")]
    public float[] _easyEnemyStatus = new float[3];
    [Tooltip("Normal用エネミーStatus")]
    public float[] _normalEnemyStatus = new float[3];
    [Tooltip("Hard用エネミーStatus")]
    public float[] _hardEnemyStatus = new float[3];
    [Tooltip("EXPART用エネミーStatus")]
    public float[] _expartEnemyStatus = new float[4];

    private LevelState _nowLevel;

    public LevelState LevelState
    {
        get => _levelState;
        set
        {
            _levelState = value;
            ChangeLevelState(_levelState);
        }
    }

    /// <summary>
    /// インスペクター上でいじる際の変更を可視化
    /// </summary>
    private void OnValidate()
    {

        // プレイヤーステータス
        _playerSpeed = Mathf.Max(1, _playerSpeed);
        _playerKnockbackDistance = Mathf.Max(1, _playerKnockbackDistance);
        _playerKnockbackTime = Mathf.Max(1, _playerKnockbackTime);
        _playerAttackInterval = Mathf.Max(1, _playerAttackInterval);

        // エネミーステータス
        _enemySpeed = Mathf.Max(1, _enemySpeed);
        _enemyKnockbackDistance = Mathf.Max(1, _enemyKnockbackDistance);
        _enemyKnockbackTime = Mathf.Max(1, _enemyKnockbackTime);
        _enemyStartPos = Mathf.Max(0,_enemyStartPos);

        StatusPutIn();
    }

    private void StatusPutIn()
    {
        switch (_levelState)
        {
            case LevelState.EASY:
                {
                    if (_nowLevel != LevelState.EASY)
                    {
                        _playerSpeed = _easyPlayerStatus[0];
                        _playerKnockbackDistance = _easyPlayerStatus[1];
                        _playerKnockbackTime = _easyPlayerStatus[2];
                        _playerAttackInterval = _easyPlayerStatus[3];

                        _enemySpeed = _easyEnemyStatus[0];
                        _enemyKnockbackDistance = _easyEnemyStatus[1];
                        _enemyKnockbackTime = _easyEnemyStatus[2];
                        _enemyStartPos = _easyEnemyStatus[3];
                    }

                    _easyPlayerStatus[0] = _playerSpeed;
                    _easyPlayerStatus[1] = _playerKnockbackDistance;
                    _easyPlayerStatus[2] = _playerKnockbackTime;
                    _easyPlayerStatus[3] = _playerAttackInterval;

                    _easyEnemyStatus[0] = _enemySpeed;
                    _easyEnemyStatus[1] = _enemyKnockbackDistance;
                    _easyEnemyStatus[2] = _enemyKnockbackTime;
                    _easyEnemyStatus[3] = _enemyStartPos;
                }
                break;

            case LevelState.NORMAL:
                {
                    if (_nowLevel != LevelState.NORMAL)
                    {
                        _playerSpeed = _normalPlayerStatus[0];
                        _playerKnockbackDistance = _normalPlayerStatus[1];
                        _playerKnockbackTime = _normalPlayerStatus[2];
                        _playerAttackInterval = _normalPlayerStatus[3];

                        _enemySpeed = _normalEnemyStatus[0];
                        _enemyKnockbackDistance = _normalEnemyStatus[1];
                        _enemyKnockbackTime = _normalEnemyStatus[2];
                        _enemyStartPos = _normalEnemyStatus[3];
                    }

                    _normalPlayerStatus[0] = _playerSpeed;
                    _normalPlayerStatus[1] = _playerKnockbackDistance;
                    _normalPlayerStatus[2] = _playerKnockbackDistance;
                    _normalPlayerStatus[3] = _playerAttackInterval;

                    _normalEnemyStatus[0] = _enemySpeed;
                    _normalEnemyStatus[1] = _enemyKnockbackDistance;
                    _normalEnemyStatus[2] = _enemyKnockbackTime;
                    _normalEnemyStatus[3] = _enemyStartPos;
                }
                break;

            case LevelState.HARD:
                {
                    if (_nowLevel != LevelState.HARD)
                    {
                        _playerSpeed = _hardPlayerStatus[0];
                        _playerKnockbackDistance = _hardPlayerStatus[1];
                        _playerKnockbackTime = _hardPlayerStatus[2];
                        _playerAttackInterval = _hardPlayerStatus[3];

                        _enemySpeed = _hardEnemyStatus[0];
                        _enemyKnockbackDistance = _hardEnemyStatus[1];
                        _enemyKnockbackTime = _hardEnemyStatus[2];
                        _enemyStartPos = _hardEnemyStatus[3];
                    }

                    _hardPlayerStatus[0] = _playerSpeed;
                    _hardPlayerStatus[1] = _playerKnockbackDistance;
                    _hardPlayerStatus[2] = _enemyKnockbackTime;
                    _hardPlayerStatus[3] = _playerAttackInterval;

                    _hardEnemyStatus[0] = _enemySpeed;
                    _hardEnemyStatus[1] = _enemyKnockbackDistance;
                    _hardEnemyStatus[2] = _enemyKnockbackTime;
                    _hardEnemyStatus[3] = _enemyStartPos;
                }
                break;

            case LevelState.EXPART:
                {
                    if(_nowLevel != LevelState.EXPART)
                    {
                        _playerSpeed = _expartPlayerStatus[0];
                        _playerKnockbackDistance = _expartPlayerStatus[1];
                        _playerKnockbackTime = _expartPlayerStatus[2];
                        _playerAttackInterval = _expartPlayerStatus[3];

                        _enemySpeed = _expartEnemyStatus[0];
                        _enemyKnockbackDistance = _expartEnemyStatus[1];
                        _enemyKnockbackTime = _expartEnemyStatus[2];
                        _enemyStartPos = _expartEnemyStatus[3];
                    }

                    _expartPlayerStatus[0] = _playerSpeed;
                    _expartPlayerStatus[1] = _playerKnockbackDistance;
                    _expartPlayerStatus[2] = _enemyKnockbackTime;
                    _expartPlayerStatus[3] = _playerAttackInterval;

                    _expartEnemyStatus[0] = _enemySpeed;
                    _expartEnemyStatus[1] = _enemyKnockbackDistance;
                    _expartEnemyStatus[2] = _enemyKnockbackTime;
                    _expartEnemyStatus[3] = _enemyStartPos;
                }
                break;
        }

        _nowLevel = LevelState;
    }

    private void ChangeLevelState(LevelState _level)
    {
        Debug.Log($"難易度が{_level}に変更された");
    }
}
