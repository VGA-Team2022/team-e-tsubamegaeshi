using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateTest : MonoBehaviour
{
    public enum BattleState
    {
        //とりあえずじゃんけん方式
        NONE = 0,
        Rock = 1,//グー/Right
        Scissors = 2,//チョキ/Light
        Paper = 3//パー/Down
    }

    [SerializeField]
    private BattleState _playerState = BattleState.NONE;

    [SerializeField]
    private BattleState _enemyState = BattleState.NONE;

    public enum BattleEndState
    {
        NONE = 0,
        Win = 1,
        Lose = 2,
        Draw = 3,
    }
    [SerializeField]
    private BattleEndState battleEndState = BattleEndState.NONE;

    [SerializeField]
    Battele _battele;

    [SerializeField]
    FlickTest _flickTest;

    [SerializeField]
    bool _isBattele;
    private void Update()
    {
        Battle();
        if (_battele.IsBattle && !_isBattele)
        {
            BattleStart();
        }
        if(_battele.IsBattle)
        {
            PlayerStateSet();
        }
    }
    void BattleStart()
    {
        _isBattele = true;
        EnemyStateSet();
        //PlayerStateSet();
    }
    void EnemyStateSet()
    {
        var rdm = Random.Range(1, 4);
        switch(rdm)
        {
            case 1:
                _enemyState = BattleState.Rock;
                break;
            case 2:
                _enemyState = BattleState.Scissors;
                break;
            case 3:
                _enemyState = BattleState.Paper;
                break;
        }
    }

    void PlayerStateSet()
    {

        switch (_flickTest.NowSwipe)
        {
            case FlickTest.FlickState.LEFT:
                _playerState = BattleState.Rock;
                break;
            case FlickTest.FlickState.RIGHT:
                _playerState = BattleState.Scissors;
                break;
            case FlickTest.FlickState.DOWN:
                _playerState = BattleState.Paper;
                break;
        }
    }

    void StateReSet()
    {
        _playerState = BattleState.NONE;
        _enemyState = BattleState.NONE;

    }
    void Battle()
    {
        switch (_playerState)
        {
            case BattleState.NONE:
                {
                }
                break;
            case BattleState.Rock:
                {
                    if (_enemyState == BattleState.Rock)
                    {
                        Debug.Log("あいこ");
                        ChangeBattleEndState(BattleEndState.Draw);
                    }
                    else if (_enemyState == BattleState.Scissors)
                    {
                        Debug.Log("勝ち");
                        ChangeBattleEndState(BattleEndState.Win);
                    }
                    else if (_enemyState == BattleState.Paper)
                    {
                        Debug.Log("負け");
                        ChangeBattleEndState(BattleEndState.Lose);
                    }
                }
                break;
            case BattleState.Scissors:
                {
                    if (_enemyState == BattleState.Rock)
                    {
                        Debug.Log("負け");
                        ChangeBattleEndState(BattleEndState.Lose);
                    }
                    else if (_enemyState == BattleState.Scissors)
                    {
                        Debug.Log("あいこ");
                        ChangeBattleEndState(BattleEndState.Draw);

                    }
                    else if (_enemyState == BattleState.Paper)
                    {
                        Debug.Log("勝ち");
                        ChangeBattleEndState(BattleEndState.Win);
                    }
                }
                break;
            case BattleState.Paper:
                {
                    if (_enemyState == BattleState.Rock)
                    {
                        Debug.Log("勝ち");
                        ChangeBattleEndState(BattleEndState.Win);
                    }
                    else if (_enemyState == BattleState.Scissors)
                    {
                        Debug.Log("負け");
                        ChangeBattleEndState(BattleEndState.Lose);

                    }
                    else if (_enemyState == BattleState.Paper)
                    {
                        Debug.Log("あいこ");
                        ChangeBattleEndState(BattleEndState.Draw);
                    }
                }
                break;
        }

    }

    public void ChangeBattleEndState(BattleEndState next)
    {
        _isBattele = false;
        // 以前の状態を保持
        var prev = battleEndState;
        // 次の状態に変更する
        battleEndState = next;
        Debug.Log($"フリック方向 {prev} -> {next}");
        switch (battleEndState)
        {
            case BattleEndState.NONE:
                {

                }
                break;

            case BattleEndState.Win:
                {

                }
                break;

            case BattleEndState.Lose:
                {

                }
                break;

            case BattleEndState.Draw:
                {

                }
                break;
        }
    }
}
