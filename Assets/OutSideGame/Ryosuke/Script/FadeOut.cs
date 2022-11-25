using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    [SerializeField] private float _fadeOutSpeed = 2.0f;
    [SerializeField] Fadeout fadeOut;

    public void Start()
    {
        fadeOut.FadeOut(_fadeOutSpeed);
    }
}
