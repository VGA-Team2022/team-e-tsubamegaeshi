using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMotion : MonoBehaviour
{
    //関数でプレイヤーのアニメーションを呼び出せる
    [SerializeField] Animator _playerAnimator;
    public void motion()
    {
        _playerAnimator.SetTrigger("New Trigger");
    }
}
