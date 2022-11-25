using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExtraButton : MonoBehaviour
{
    public void OnExtraStageButtonDown()
    {
        AudioManager.Instance.PlaySE("BattleEnemyRepel");

        SceneManager.LoadScene("ExtraStage");
    }

}
