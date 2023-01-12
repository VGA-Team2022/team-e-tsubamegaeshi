using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyStateController : MonoBehaviour
{

    [SerializeField]
    private Animator _animator;
    void Awake()
    {
        if (_animator == null)
        {
            _animator = GetComponent<Animator>();
        }
    }

    public void OnEnemyChangeMode(StateManager.BattleState janken)
    {
        switch (ResultManager._resultState)
        {
            case ResultState.NONE:
                {
                    switch (janken)
                    {
                        case StateManager.BattleState.NONE:

                            break;
                        case StateManager.BattleState.Rock:
                            _animator.Play("EnemyAttackRed");
                            Debug.Log($"Enemyのアニメーション{StateManager.BattleState.Rock}を再生");
                            break;
                        case StateManager.BattleState.Scissors:
                            _animator.Play("EnemyAttackBlue");
                            Debug.Log($"Enemyのアニメーション{StateManager.BattleState.Scissors}を再生");
                            break;
                        case StateManager.BattleState.Paper:
                            _animator.Play("EnemyAttackGreen");
                            Debug.Log($"Enemyのアニメーション{StateManager.BattleState.Paper}を再生");
                            break;
                        case StateManager.BattleState.Special:
                            _animator.Play("EnemyAttackSpecial");
                            Debug.Log($"Enemyのアニメーション{StateManager.BattleState.Special}を再生");
                            break;
                    }
                }
                break;

            case ResultState.WIN:
                {
                    _animator.Play("Death");
                }
                break;

            case ResultState.LOSE:
                {
                    _animator.Play("EnemyWin");
                }
                break;
        }
    }

    public void OnEnemyBsttle(StateManager.BattleEndState shouhai)
    {
        switch (shouhai)
        {
            case StateManager.BattleEndState.NONE:
                break;
            case StateManager.BattleEndState.Win:
                Debug.Log($"Enemyの勝敗{StateManager.BattleEndState.Win}を再生");
                break;
            case StateManager.BattleEndState.Lose:
                Debug.Log($"Enemyの勝敗{StateManager.BattleEndState.Lose}を再生");
                break;
            case StateManager.BattleEndState.Draw:
                Debug.Log($"Enemyrの勝敗{StateManager.BattleEndState.Draw}を再生");
                break;
        }
    }
}
