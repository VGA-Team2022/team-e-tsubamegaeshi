using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class SceneSelector : MonoBehaviour
{
    [Serializable]
    class ChangeSetting
    {
        public string Scene;
        public Button Button;
    }

    [Header("画面の遷移管理")]
    [Header("フェードインの遷移時間を決められるよ")]
    [SerializeField] private float _fadeTime = 2.0f;
    [SerializeField] string se;
    [SerializeField] Fade fade;
    [SerializeField] List<ChangeSetting> Setting;

    private void Awake()
    {
        Setting.ForEach(s =>
        {
            s.Button.onClick.AddListener(() =>
            {
                AudioManager.Instance.PlaySE(se);
                fade.FadeIn(_fadeTime, () => SceneManager.LoadScene(s.Scene));
            });
        });
    }
}
