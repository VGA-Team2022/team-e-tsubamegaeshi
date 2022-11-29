using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selector : MonoBehaviour
{
    [Header("メイン画面の遷移管理")]
    [Header("遷移の時間を決められるよ")]

    [Tooltip("フェイドイン、アウトのスピードが変えられるよ")]
    [SerializeField] private float _fadeTime = 2.0f;
    [SerializeField] Fade fade;

    public void OnClickStartButton()
    {
        AudioManager.Instance.PlaySE("BattleEnemyRepel");
        fade.FadeIn(_fadeTime , () => SceneManager.LoadScene("StageScene"));
    }

    public void OnClickOptionButton()
    {
        AudioManager.Instance.PlaySE("BattleEnemyRepel");
        fade.FadeIn(_fadeTime , () => SceneManager.LoadScene("OptionScene"));
    }
}
