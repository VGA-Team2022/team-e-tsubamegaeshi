using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StateTest;

public class PlayerState : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      

    }

    public void OnPlayerChangeMode(StateTest.BattleState janken)
    {
        switch (janken)
        {
            case StateTest.BattleState.NONE:

                break;
            case StateTest.BattleState.Rock:
                _animator.Play("PlayerAttackRed");
                Debug.Log($"Playerのアニメーション{StateTest.BattleState.Rock}を再生");
                break;
            case StateTest.BattleState.Scissors:
                _animator.Play("PlayerAttackBlue");
                Debug.Log($"Playerのアニメーション{StateTest.BattleState.Scissors}を再生");
                break;
            case StateTest.BattleState.Paper:
                _animator.Play("PlayerAttackGreen");
                Debug.Log($"Playerのアニメーション{StateTest.BattleState.Paper}を再生");
                break;
        }

    }

    public void OnPlayerBsttle(StateTest.BattleEndState shouhai)
    {
        switch (shouhai)
        {
            case StateTest.BattleEndState.NONE:
                break;
            case StateTest.BattleEndState.Win:
                Debug.Log($"Playerの勝敗{StateTest.BattleEndState.Win}を再生");
                break;
            case StateTest.BattleEndState.Lose:
                Debug.Log($"Playerの勝敗{StateTest.BattleEndState.Lose}を再生");
                break;
            case StateTest.BattleEndState.Draw:
                Debug.Log($"Playerの勝敗{StateTest.BattleEndState.Draw}を再生");
                break;
        }
    }
}
