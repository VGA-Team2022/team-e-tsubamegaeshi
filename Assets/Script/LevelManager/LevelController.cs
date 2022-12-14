using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                instance = FindObjectOfType<LevelController>();
            }

            return instance;
        }
    }

    /// <summary>
    /// 難易度のState
    /// </summary>
    public enum LevelState
    {
        EASY = 0,
        NORMAL = 1,
        HARD = 2,
    }

    [Header("難易度")]
    public LevelState _levelState;

    [Header("プレイヤー用ステータス")]
    [SerializeField]
    private float _playerSpeed = 1;
    [SerializeField]
    private float _playerKnockbackDistance = 1f;
    [SerializeField]
    private float _playerKnockbackTime = 1f;

    [Header("エネミー用ステータス")]
    [SerializeField]
    private float _enemySpeed = 1;
    [SerializeField]
    private float _enemyKnockbackDistance = 1f;
    [SerializeField]
    private float _enemyKnockbackTime = 1f;

    // プレイヤーのステータスを保存 
    // 1.Speed 2.KnockbackDistance 3.KnockbackTime
    [System.NonSerialized] public float[] _easyPlayerStatus = new float[3];
    [System.NonSerialized] public float[] _normalPlayerStatus = new float[3];
    [System.NonSerialized] public float[] _hardPlayerStatus = new float[3];

    // エネミーのステータスを保存
    // 1.Speed 2.KnockbackDistance 3.KnockbackTime
    [System.NonSerialized] public float[] _easyEnemyStatus = new float[3];
    [System.NonSerialized] public float[] _normalEnemyStatus = new float[3];
    [System.NonSerialized] public float[] _hardEnemyStatus = new float[3];

    /// <summary>
    /// インスペクター上でいじる際の変更を可視化
    /// </summary>
    private void OnValidate()
    {
        // プレイヤーステータス
        _playerSpeed = Mathf.Max(1, _playerSpeed);
        _playerKnockbackDistance = Mathf.Max(1, _playerKnockbackDistance);
        _playerKnockbackTime = Mathf.Max(1, _playerKnockbackTime);

        // エネミーステータス
        _enemySpeed = Mathf.Max(1, _enemySpeed);
        _enemyKnockbackDistance = Mathf.Max(1, _enemyKnockbackDistance);
        _enemyKnockbackTime = Mathf.Max(1, _enemyKnockbackTime);

        switch (_levelState)
        {
            case LevelState.EASY:
                {

                }
                break;

            case LevelState.NORMAL:
                {

                }
                break;

            case LevelState.HARD:
                {

                }
                break;
        }
    }
}
