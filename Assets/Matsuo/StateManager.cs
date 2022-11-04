using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public enum BattleState
    {
        //とりあえずじゃんけん方式
        NONE = 0,
        Rock = 1,//グー/Right
        Scissors = 2,//チョキ/Light
        Paper = 3//パー/Down
    }

    public BattleState _playerState = BattleState.NONE;

    public BattleState _enemyState = BattleState.NONE;

    public enum BattleEndState//勝敗
    {
        NONE = 0,
        Win = 1,
        Lose = 2,
        Draw = 3,
    }
    public BattleEndState battleEndState = BattleEndState.NONE;

    //[SerializeField]
    //Battele _battele;

    public float _interval = 1f;

    bool BattleCheck = false;

    [SerializeField]//確認用
    private FlickManager _flickTest;//フリック方向

    [SerializeField]//確認用
    private DistanceManager _distanceManager;//バトル判定

    [SerializeField]
    private ActionOnDisplay _actionOnDisplay; // 攻撃表示

    public PlayerStateController _playerStateController;
    public EnemyStateController _enemyStateController;
    

    //[SerializeField]
    //bool _isBattele;
    private void Update()
    {
        if (!_distanceManager._isCheck)
        {
            PlayerStateSet();
        }
    }

    /// <summary>
    /// 戦闘開始時に呼ぶ処理
    /// </summary>
    public void BattleStart()
    {
        //_isBattele = true;
        Debug.Log("戦闘開始");
        EnemyStateSet();
        //PlayerStateSet();
    }

    /// <summary>
    /// エネミーの出す手を決めて変更する処理
    /// </summary>
    public void EnemyStateSet()
    {
        var rdm = Random.Range(1, 4);
        switch (rdm)
        {
            case 1:
                _enemyState = BattleState.Rock;
                _enemyStateController.OnEnemyChangeMode(BattleState.Rock);
                _actionOnDisplay.OnDisplay(Color.red);
                Debug.Log($"敵:{BattleState.Rock}");
                break;
            case 2:
                _enemyState = BattleState.Scissors;
                _enemyStateController.OnEnemyChangeMode(BattleState.Scissors);
                _actionOnDisplay.OnDisplay(Color.yellow);
                Debug.Log($"敵:{BattleState.Scissors}");
                break;
            case 3:
                _enemyState = BattleState.Paper;
                _enemyStateController.OnEnemyChangeMode(BattleState.Paper);
                _actionOnDisplay.OnDisplay(Color.blue);
                Debug.Log($"敵:{BattleState.Paper}");
                break;
        }
    }

    /// <summary>
    /// デバック用
    /// </summary>
    void PlayerStateSet()
    {
        switch (_flickTest.NowSwipe)
        {
            case FlickManager.FlickState.LEFT:
                _playerState = BattleState.Rock;
                _playerStateController.OnPlayerChangeMode(BattleState.Rock);
                Battle();
                Debug.Log($"プレイヤー:{BattleState.Rock}");
                break;
            case FlickManager.FlickState.RIGHT:
                _playerState = BattleState.Scissors;
                _playerStateController.OnPlayerChangeMode(BattleState.Scissors);
                Battle();
                Debug.Log($"プレイヤー:{BattleState.Scissors}");
                break;
            case FlickManager.FlickState.DOWN:
                _playerState = BattleState.Paper;
                _playerStateController.OnPlayerChangeMode(BattleState.Paper);
                Battle();
                Debug.Log($"プレイヤー:{BattleState.Paper}");
                break;
            case FlickManager.FlickState.NONE:
                _playerState = BattleState.NONE;
                //Debug.Log($"プレイヤー:{BattleState.NONE}");
                break;
        }
    }
    /// <summary>
    /// デバック用ステートリセット
    /// </summary>
    void StateReSet()
    {
        Debug.Log("リセット");
        //_playerState = BattleState.NONE;
        //_enemyState = BattleState.NONE;
        //battleEndState = BattleEndState.NONE;
        BattleCheck = true;
        StartCoroutine(nameof(BattleInterval));
    }

    /// <summary>
    /// 勝敗を判定する処理
    /// </summary>
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
                        //Debug.Log("あいこ");
                        ChangeBattleEndState(BattleEndState.Draw);
                    }
                    else if (_enemyState == BattleState.Scissors)
                    {
                        //Debug.Log("勝ち");
                        ChangeBattleEndState(BattleEndState.Win);
                    }
                    else if (_enemyState == BattleState.Paper)
                    {
                        //Debug.Log("負け");
                        ChangeBattleEndState(BattleEndState.Lose);
                    }

                }
                break;
            case BattleState.Scissors:
                {
                    if (_enemyState == BattleState.Rock)
                    {
                        //Debug.Log("負け");
                        ChangeBattleEndState(BattleEndState.Lose);
                    }
                    else if (_enemyState == BattleState.Scissors)
                    {
                        //Debug.Log("あいこ");
                        ChangeBattleEndState(BattleEndState.Draw);

                    }
                    else if (_enemyState == BattleState.Paper)
                    {
                        //Debug.Log("勝ち");
                        ChangeBattleEndState(BattleEndState.Win);
                    }
                }
                break;
            case BattleState.Paper:
                {
                    if (_enemyState == BattleState.Rock)
                    {
                        //Debug.Log("勝ち");
                        ChangeBattleEndState(BattleEndState.Win);
                    }
                    else if (_enemyState == BattleState.Scissors)
                    {
                        //Debug.Log("負け");
                        ChangeBattleEndState(BattleEndState.Lose);

                    }
                    else if (_enemyState == BattleState.Paper)
                    {
                        //Debug.Log("あいこ");
                        ChangeBattleEndState(BattleEndState.Draw);
                    }
                }
                break;
        }

    }

    /// <summary>
    /// ここに勝敗の後の処理を書くもしくは呼び出す
    /// </summary>
    /// <param name="next"></param>
    public void ChangeBattleEndState(BattleEndState next)
    {
        //_isBattele = false;

        if(BattleCheck) { return; }

        var prev = battleEndState;
        battleEndState = next;
        switch (battleEndState)
        {
            case BattleEndState.NONE:
                {

                }
                break;

            case BattleEndState.Win:
                {
                    Debug.Log($"戦闘結果{next}");
                    _distanceManager?.SetUp(BattleEndState.Win);
                    StateReSet();
                }
                break;

            case BattleEndState.Lose:
                {
                    Debug.Log($"戦闘結果{next}");
                    _distanceManager?.SetUp(BattleEndState.Lose);
                    StateReSet();  
                }
                break;

            case BattleEndState.Draw:
                {
                    Debug.Log($"戦闘結果{next}");
                    _distanceManager?.SetUp(BattleEndState.Draw);
                    StateReSet();
                }
                break;
        }
    }

    IEnumerator BattleInterval()
    {
        yield return new WaitForSeconds(_interval);
        BattleCheck = false;
    }
}
