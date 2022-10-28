using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyState : MonoBehaviour
{

    [SerializeField]
    private Animator _animator;
    void Start()
    {
        _animator =  GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnEnemyChangeMode(StateTest.BattleState janken)
    {
        switch (janken)
        {
            case StateTest.BattleState.NONE:

                break;
            case StateTest.BattleState.Rock:
                _animator.Play("EnemyAttackRed");
                Debug.Log($"Enemyのアニメーション{StateTest.BattleState.Rock}を再生");
                break;
            case StateTest.BattleState.Scissors:
                _animator.Play("EnemyAttackBlue");
                Debug.Log($"Enemyのアニメーション{StateTest.BattleState.Scissors}を再生");
                break;
            case StateTest.BattleState.Paper:
                _animator.Play("EnemyAttackGreen");
                Debug.Log($"Enemyのアニメーション{StateTest.BattleState.Paper}を再生");
                break;
        }

    }

    public void OnEnemyBsttle(StateTest.BattleEndState shouhai)
    {
        switch (shouhai)
        {
            case StateTest.BattleEndState.NONE:
                break;
            case StateTest.BattleEndState.Win:
                Debug.Log($"Enemyの勝敗{StateTest.BattleEndState.Win}を再生");
                break;
            case StateTest.BattleEndState.Lose:
                Debug.Log($"Enemyの勝敗{StateTest.BattleEndState.Lose}を再生");
                break;
            case StateTest.BattleEndState.Draw:
                Debug.Log($"Enemyrの勝敗{StateTest.BattleEndState.Draw}を再生");
                break;
        }
    }
}
