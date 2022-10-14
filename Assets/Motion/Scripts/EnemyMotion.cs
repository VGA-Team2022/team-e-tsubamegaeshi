using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMotion : MonoBehaviour
{
    //関数で敵のアニメーションを呼び出せる
    [SerializeField] Animator _enemyAnimator;
    public void motion()
    {
        _enemyAnimator.Play("New Trigger");
    }

    public void EnemyWalk()
    {
        _enemyAnimator.Play("KnockBack");
    }
}
