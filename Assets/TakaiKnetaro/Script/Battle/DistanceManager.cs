using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DG.Tweening;

//TODO
//PlayerとEnemy両方の管理を行うとコード量が多くなるかも
//必要であれば分割する

/// <summary>
/// シーン内のPlayerとEnemyの位置を管理する
/// </summary>
public class DistanceManager : MonoBehaviour
{
    [Header("プレイヤー")]
    [SerializeField, Tooltip("プレイヤーのプレハブ")]
    private GameObject _playerPrefab;
    [SerializeField, Tooltip("プレイヤーのスピード")]
    private float _playerSpeed = 1;
    [SerializeField, Tooltip("プレイヤーの初期座標")]
    private Transform _playerInitPos;

    [Header("敵")]
    [SerializeField, Tooltip("敵のプレハブ")]
    private GameObject _enemyPrefab;
    [SerializeField, Tooltip("敵のスピード")]
    private float _enemySpeed = 1;
    [SerializeField, Tooltip("敵の初期座標")]
    private Transform _enemyInitPos;
    [SerializeField, Tooltip("ノックバックの威力")]
    private float _kbDistance = 1f;
    [SerializeField, Tooltip("ノックバックされてる時間")]
    private float _kbTime = 1f;

    [Header("ステージ設定")]
    [SerializeField, Tooltip("ステージの最左")]
    private Transform _start;
    [SerializeField, Tooltip("ステージの最右")]
    private Transform _end;
    [SerializeField, Tooltip("静止する線形距離")]
    private float _stopDistance = 0.05f;

    [Tooltip("プレイヤーの現在の座標")]
    private Vector3 _playerCurrentPos;
    [Tooltip("敵の現在の座標")]
    private Vector3 _enemyCurrentPos;

    private GameObject _player;
    private GameObject _enemy;

    private float _sum = 0;

    private bool _isMove = false;

    private void Start()
    {
        if (_start.position.x >= _end.position.x)
        {
            Debug.LogError("座標が不正な値です");
            return;
        }
        _sum = Mathf.Abs(_start.position.x) + Mathf.Abs(_end.position.x);

        if (_playerPrefab != null)
        {
            _player = Instantiate(_playerPrefab, _playerInitPos.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("プレハブにPlayerを設定してください");
        }

        if (_enemyPrefab != null)
        {
            _enemy = Instantiate(_enemyPrefab, _enemyInitPos.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("プレハブにEnemyを設定してください");
        }

        if (_kbDistance <= 0)
        {
            Debug.LogError("ノックバック距離の値を設定してください");
        }
        if (_kbTime <= 0)
        {
            Debug.Log("ノックバック時間を設定してください");
        }

        _isMove = true;

        Init();
    }

    /// <summary>
    /// PlayerとEnemyの位置情報の初期化
    /// </summary>
    public void Init()
    {
        if (_playerInitPos != null)
        {
            _playerCurrentPos = _playerInitPos.position;
        }
        if (_enemyInitPos != null)
        {
            _enemyCurrentPos = _enemyInitPos.position;
        }
    }

    private void Update()
    {
        if (_isMove == false) return;

        PlayerMove(_player.transform);
        EnemyMove(_enemy.transform);

        float playerLerp = LerpTranslate(_player.transform.position.x);
        float enemyLerp = LerpTranslate(_enemy.transform.position.x);

        _isMove = DistanceCheck(playerLerp, enemyLerp);
    }

    /// <summary>
    /// 与えられた値を線形補完に変換する
    /// </summary>
    /// <param name="xPos">変換する座標のX座標</param>
    /// <returns></returns>
    private float LerpTranslate(float xPos)
    {
        if (_start.position.x > xPos || _end.position.x < xPos)
        {
            Debug.LogError("Stageから外れています");
            return 0;
        }

        float value = (xPos - _start.position.x) / _sum;
        Debug.Log(value);
        return value;
    }

    /// <summary>
    /// Playerの移動、Transform.Translateを使う
    /// </summary>
    /// <param name="tr"></param>
    private void PlayerMove(Transform tr)
    {
        tr.Translate(Vector3.right * Time.deltaTime * _playerSpeed);
    }

    /// <summary>
    /// Enemyの移動、Transform.Translateを使う
    /// </summary>
    /// <param name="tr"></param>
    private void EnemyMove(Transform tr)
    {
        tr.Translate(Vector3.left * Time.deltaTime * _enemySpeed);
    }

    /// <summary>
    /// プレイヤーとエネミーの距離比較
    /// </summary>
    /// <param name="p"></param>
    /// <param name="e"></param>
    /// <returns></returns>
    private bool DistanceCheck(float p, float e)
    {
        if (e - p <= _stopDistance)
        {
            KnockBackEnemy();
            return false;
        }
        else
        {
            return true;
        }
    }

    private void KnockBackEnemy()
    {
        _enemy.transform.DOLocalMove
            (_enemy.transform.position + _enemy.transform.right * _kbDistance, _kbTime)
            .OnComplete(() => _isMove = true
            );

    }
}