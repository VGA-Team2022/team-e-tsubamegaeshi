using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum Chara
{
    Player = 0,
    Enemy = 1,
}

public class CharacterScript : MonoBehaviour
{
    [Header("キャラクター")]
    [SerializeField, Tooltip("クラスを入れてるオブジェクトのキャラ")]
    private Chara _chara;
    [SerializeField, Tooltip("キャラのスピード")]
    private float _charaSpeed = 1;
    [SerializeField, Tooltip("キャラのノックバック威力")]
    private float _kbDis = 1f;
    [SerializeField, Tooltip("キャラのノックバックされてる時間")]
    private float _kbTime = 1f;

    public bool _isMove = false;

    private void Start()
    {
        switch (LevelController.Instance.LevelState)
        {
            case LevelState.EASY:
                {
                    if(_chara == Chara.Player)
                    {
                        _charaSpeed = LevelController.Instance._easyPlayerStatus[0];
                        _kbDis = LevelController.Instance._easyPlayerStatus[1];
                        _kbTime = LevelController.Instance._easyPlayerStatus[2];
                    }
                    else if(_chara == Chara.Enemy)
                    {
                        _charaSpeed = LevelController.Instance._easyEnemyStatus[0];
                        _kbDis = LevelController.Instance._easyEnemyStatus[1];
                        _kbTime = LevelController.Instance._easyEnemyStatus[2];
                    }
                }
                break;

            case LevelState.NORMAL:
                {
                    if (_chara == Chara.Player)
                    {
                        _charaSpeed = LevelController.Instance._normalPlayerStatus[0];
                        _kbDis = LevelController.Instance._normalPlayerStatus[1];
                        _kbTime = LevelController.Instance._normalPlayerStatus[2];
                    }
                    else if (_chara == Chara.Enemy)
                    {
                        _charaSpeed = LevelController.Instance._normalEnemyStatus[0];
                        _kbDis = LevelController.Instance._normalEnemyStatus[1];
                        _kbTime = LevelController.Instance._normalEnemyStatus[2];
                    }
                }
                break;

            case LevelState.HARD:
                {
                    if (_chara == Chara.Player)
                    {
                        _charaSpeed = LevelController.Instance._hardPlayerStatus[0];
                        _kbDis = LevelController.Instance._hardPlayerStatus[1];
                        _kbTime = LevelController.Instance._hardPlayerStatus[2];
                    }
                    else if (_chara == Chara.Player)
                    {
                        _charaSpeed = LevelController.Instance._hardEnemyStatus[0];
                        _kbDis = LevelController.Instance._hardEnemyStatus[1];
                        _kbTime = LevelController.Instance._hardEnemyStatus[2];
                    }
                }
                break;
        }

        if (_charaSpeed <= 0) { Debug.LogError("移動する値を設定してください"); }
        if (_kbDis <= 0) { Debug.LogError("ノックバック距離の値を設定してください"); }
        if (_kbTime <= 0) { Debug.LogError("ノックバック時間を設定してください"); }

        _isMove = false;
    }

    private void Update()
    {
        if (_isMove) return;

        CharaMove(this.gameObject.transform);
    }

    private void CharaMove(Transform tr)
    {
        if (_chara == Chara.Player)
        {
            tr.Translate(Vector3.right * Time.deltaTime * _charaSpeed);
        }
        else if (_chara == Chara.Enemy)
        {
            tr.Translate(Vector3.left * Time.deltaTime * _charaSpeed);
        }
    }

    public void KnockBack()
    {
        if (_chara == Chara.Player)
        {
            gameObject.transform.DOLocalMove
            (gameObject.transform.position + (gameObject.transform.right * -1) * _kbDis, _kbTime);
            _isMove = true;
        }
        else if (_chara == Chara.Enemy)
        {
            gameObject.transform.DOLocalMove
            (gameObject.transform.position + gameObject.transform.right * _kbDis, _kbTime);
            _isMove = true;
        }
    }

    public void MoveStart()
    {
        if (_isMove)
        {
            _isMove = false;
        }
    }
}
