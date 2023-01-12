using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ResultState
{
    WIN = 0,
    LOSE = 1,
    NONE = 2,
}

public class ResultManager : MonoBehaviour
{
    static public ResultState _resultState = ResultState.NONE;

    [SerializeField]
    private Text _text;

    void Start()
    {
        switch (_resultState)
        {
            case ResultState.WIN: //Ÿ‚Á‚½‚Ìˆ—
                {
                    ResultWin();
                }
                break;

            case ResultState.LOSE: //•‰‚¯‚½‚Ìˆ—
                {
                    ResultLose();
                }
                break;
        }

    }

    private void ResultWin()
    {
        _text.text = "Ÿ‚¿";
    }

    private void ResultLose()
    {
        _text.text = "•‰‚¯";
    }

}
