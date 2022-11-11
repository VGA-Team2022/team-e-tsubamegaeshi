using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EasyButton : MonoBehaviour
{
    //難易度「イージー」に遷移するためのボタン

    public void OnClickEasyButton()
    {
        SceneManager.LoadScene("EasyScene");
    }
}
