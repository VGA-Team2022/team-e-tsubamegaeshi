using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageButton : MonoBehaviour
{
    //ステージ遷移用スクリプト

    public void OnClickStartButton()
    {
        AudioManager.Instance.PlaySE("BattleEnemyRepel");
        SceneManager.LoadScene("StageScene");
    }



}
