using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyStateController : MonoBehaviour
{

    [SerializeField]
    private Animator _animator;
    void Start()
    {
        if (_animator == null)
        {
            _animator = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnEnemyChangeMode(StateManager.BattleState janken)
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
