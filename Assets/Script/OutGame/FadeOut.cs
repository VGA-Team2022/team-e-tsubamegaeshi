using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    [Header("ここでフェードのスピートを変えれるよ")]
    [Header("遷移時間を決めれるよ")]
    [SerializeField] private float _fadeOutSpeed = 2.0f;
    [SerializeField,Header("ここにFadeOutCanvasを入れてください")] Fadeout fadeOut;

    public void Start()
    {
        fadeOut.FadeOut(_fadeOutSpeed);
    }
}
