using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battele : MonoBehaviour
{
    [SerializeField]
    GameObject _player;
    [SerializeField]
    GameObject _enemy;

    [SerializeField]
    Transform _playerSpown;
    [SerializeField]
    Transform _enemySpown;

    [SerializeField]
    float _playerDistance;

    [SerializeField]
    float _battle;

    [SerializeField]
    float _moveSpeed = 1f;

    [SerializeField]
    bool _isCanMove = true;
    [SerializeField]
    bool _isBattle = false;
    public bool IsBattle { get => _isBattle;}

    void Start()
    {
        _player = Instantiate(_player);
        _enemy = Instantiate(_enemy);
        _player.transform.position = _playerSpown.transform.position;
        _enemy.transform.position = _enemySpown.transform.position;
    }

    void Update()
    {
        _playerDistance = Vector3.Distance(_player.transform.position, _enemy.transform.position);

        Vector3 _playerPos = _player.transform.position;
        Vector3 _enemyPos = _enemy.transform.position;

        if(_isCanMove)
        {
            _playerPos.x += 0.01f * _moveSpeed;
            _enemyPos.x -= 0.01f * _moveSpeed;

            _player.transform.position = _playerPos;
            _enemy.transform.position = _enemyPos;
        }


        if (_playerDistance <= _battle && !_isBattle)
        {

            BattleStart();
        }

        if(_player.transform.position.x >= 8)
        {
            _isCanMove = false;
            Debug.Log("クリア");
        }
        if (_enemy.transform.position.x <= -8)
        {
            _isCanMove = false;
            Debug.Log("オーバー");

        }
    }

    void BattleStart()
    {
        _isCanMove = false;
        _isBattle = true;
        Debug.Log("戦闘開始");
    }


}
