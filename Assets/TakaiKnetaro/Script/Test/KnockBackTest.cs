using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class KnockBackTest : MonoBehaviour
{
    [SerializeField] float _addPower;
    [SerializeField] float _count;

    public void KnockBack()
    {
        this.transform.DOLocalMove(this.transform.position + transform.right * _addPower, _count);
    }
}
