using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NomalButton : MonoBehaviour
{
    //難易度「ノーマル」に遷移するためのボタン

    public void OnClickNomalButton()
    {
        AudioManager.Instance.PlaySE("SE_RepelEnemy_DEMO_Ver.2_20221101");
        SceneManager.LoadScene("NomalScene");
    }
    
}
