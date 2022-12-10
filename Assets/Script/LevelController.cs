using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    /// <summary>
    /// 難易度のState
    /// </summary>
    public enum LevelState
    {
        EASY = 0,
        NORMAL = 1,
        HARD = 2,
    }

    public LevelState _levelState => LevelState.EASY;

    [Header("Easy用ステータス")]
    [Header("プレイヤー")]
    [SerializeField]
    private float _easyPlayerSpeed = 1;
    [SerializeField]
    private float _easyPlayerKnockbackDistance = 1f;
    [SerializeField]
    private float _easyPlayerKnockbackTime = 1f;
    [Header("エネミー")]
    [SerializeField]
    private float _easyEnemySpeed = 1;
    [SerializeField]
    private float _easyEnemyKnockbackDistance = 1f;
    [SerializeField]
    private float _easyEnemyKnockbackTime = 1f;

    [Header("Normal用ステータス")]

    [Header("Hard用ステータス")]
    int _enemyKnockbackLevel = 0;
}
