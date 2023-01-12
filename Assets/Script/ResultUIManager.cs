using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultUIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _victoryUi;
    [SerializeField]
    private GameObject _LoseUi;

    private void Start()
    {
        if(ResultManager._resultState == ResultState.WIN)
        {
            _victoryUi.SetActive(true);
            _LoseUi.SetActive(false);
        }
        else
        {
            _victoryUi.SetActive(false);
            _LoseUi.SetActive(true);
        }
    }
}
