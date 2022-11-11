using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NomalButton : MonoBehaviour
{
    //難易度「ノーマル」に遷移するためのボタン

    public void OnClickNomalButton()
    {
        SceneManager.LoadScene("NomalScene");
    }
    
}
