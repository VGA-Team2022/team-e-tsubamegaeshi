using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeResult : MonoBehaviour
{
    public void GoResult()
    {
        SceneManager.LoadScene("Result");
    }
}
