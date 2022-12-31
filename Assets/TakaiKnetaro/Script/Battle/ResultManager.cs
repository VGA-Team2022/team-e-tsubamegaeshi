using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResultState
{
    WIN = 0,
    LOSE = 1,
}

public class ResultManager : MonoBehaviour
{
    static public ResultState _resultState;

    void Start()
    {
        switch (_resultState)
        {
            case ResultState.WIN: //Ÿ‚Á‚½‚Ìˆ—
                {

                }
                break;

            case ResultState.LOSE: //•‰‚¯‚½‚Ìˆ—
                {

                }
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
