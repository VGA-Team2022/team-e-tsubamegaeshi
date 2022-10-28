using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionButton : MonoBehaviour
{
    //オプションシーン遷移用スクリプト

    public void OnClickOptionButton()
    {
        SceneManager.LoadScene("OptionScene");
    }
}
