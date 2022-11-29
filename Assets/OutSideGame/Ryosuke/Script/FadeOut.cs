using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    [Header("ここでフェードのスピートを変えれるよ")]
    [Header("遷移時間を決めれるよヨ")]
    [SerializeField] private float _fadeOutSpeed = 2.0f;
    [SerializeField] Fadeout fadeOut;

    public void Start()
    {
        fadeOut.FadeOut(_fadeOutSpeed);
    }
}
