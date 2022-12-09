using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    [SerializeField]
    private Animator _hisatu;

    [SerializeField]
    Transform _range = default;

    [SerializeField]
    private Vector3 _hani;

    private void Start()
    {
        _hisatu = GetComponent<Animator>();
       // _range = GetComponent<DistanceManager>()._enemy.transform;

    }

    

    public void Kyori()
    {
        if (_range.transform.position.x >= _hani.x)
        {
            //アニメーションを発生
            Debug.Log("必殺技可能");
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{

    //    Kyori();
    //}





}
