using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StateManager;

public class PlayerStateController : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    void Start()
    {
        if(_animator == null)
        {
            _animator = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
      

    }

    public void OnPlayerChangeMode(StateManager.BattleState janken)
    {
        switch (janken)
        {
            case StateManager.BattleState.NONE:

                break;
            case StateManager.BattleState.Rock:
                _animator.Play("PlayerAttackRed");
                Debug.Log($"Playerのアニメーション{StateManager.BattleState.Rock}を再生");
                break;
            case StateManager.BattleState.Scissors:
                _animator.Play("PlayerAttackBlue");
                Debug.Log($"Playerのアニメーション{StateManager.BattleState.Scissors}を再生");
                break;
            case StateManager.BattleState.Paper:
                _animator.Play("PlayerAttackGreen");
                Debug.Log($"Playerのアニメーション{StateManager.BattleState.Paper}を再生");
                break;
        }

    }

    public void OnPlayerBsttle(StateManager.BattleEndState shouhai)
    {
        switch (shouhai)
        {
            case StateManager.BattleEndState.NONE:
                break;
            case StateManager.BattleEndState.Win:
                Debug.Log($"Playerの勝敗{StateManager.BattleEndState.Win}を再生");
                break;
            case StateManager.BattleEndState.Lose:
                Debug.Log($"Playerの勝敗{StateManager.BattleEndState.Lose}を再生");
                break;
            case StateManager.BattleEndState.Draw:
                Debug.Log($"Playerの勝敗{StateManager.BattleEndState.Draw}を再生");
                break;
        }
    }
}
