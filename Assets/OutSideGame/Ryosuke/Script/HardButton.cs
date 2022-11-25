using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HardButton : MonoBehaviour
{
    //難易度「ハード」に遷移するためのボタン

    public void OnClickHardButton()
    {
        AudioManager.Instance.PlaySE("BattleEnemyRepel1");
        SceneManager.LoadScene("HardScene");
    }
}
