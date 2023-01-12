using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeResult : MonoBehaviour
{
    [Header("移動までに掛かる時間")]
    [SerializeField]
    private float _winTimer;
    [SerializeField]
    private float _loseTimer;

    private float time;
    public void MoveScene()
    {
        switch(ResultManager._resultState)
        {
            case ResultState.WIN:
                {
                    time = _winTimer;
                    StartCoroutine(GoResultTimer());
                }
                break;
            case ResultState.LOSE:
                {
                    time = _loseTimer;
                    StartCoroutine(GoResultTimer());
                }
                break;
        }
    }

    IEnumerator  GoResultTimer()
    {
        Debug.Log(ResultManager._resultState);
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Result");
    }
}
