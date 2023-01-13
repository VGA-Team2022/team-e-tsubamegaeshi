using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static StateManager;

public class PlayerStateController : MonoBehaviour
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

    public void OnPlayerChangeMode(StateManager.BattleState janken)
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
                        case StateManager.BattleState.Special:
                            _animator.Play("PlayerSpecialAttack");
                            //AudioManager.Instance.PlaySE("Voice_TsubameGaeshi");
                            Debug.Log($"Playerのアニメーション{StateManager.BattleState.Special}を再生");
                            break;
                    }
                }
                break;

            case ResultState.WIN:
                {
                    _animator.Play("Win");
                }
                break;

                case ResultState.LOSE:
                {
                    _animator.Play("Death");
                }
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
