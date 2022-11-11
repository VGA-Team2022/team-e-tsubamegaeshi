using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionButton : MonoBehaviour
{
    //オプションシーン遷移用スクリプト

    public void OnClickOptionButton()
    {
        AudioManager.Instance.PlaySE("SE_RepelEnemy_DEMO_Ver.2_20221101");
        SceneManager.LoadScene("OptionScene");
    }
}
