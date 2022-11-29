using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionOnDisplay : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _actionImage; // UŒ‚‚Ì‰æ‘œ
    [Header("‰æ‘œ")]
    [SerializeField] private Sprite _actionRed;
    [SerializeField] private Sprite _actionBlue;
    [SerializeField] private Sprite _actionGreen;

    private float _displayTime = 1f; // ‰æ‘œ‚Ì•\¦ŠÔ

    private void Start()
    {
        //_actionImage = GameObject.Find("ActionDisplay").GetComponent<Renderer>();
        //_actionImage.gameObject.SetActive(false);
    }

    public void OnDisplay(int colornum, float time)
    {
        if(_actionImage == null) 
        {
            _actionImage = GameObject.Find("ActionDisplay").GetComponent<SpriteRenderer>();
            _actionImage.gameObject.SetActive(false);
        }

        _displayTime = time;

        if(colornum == 0)
        {
            _actionImage.sprite = _actionRed;
        }
        else if(colornum == 1)
        {
            _actionImage.sprite = _actionBlue;
        }
        else if(colornum == 2)
        {
            _actionImage.sprite = _actionGreen;
        }
        else
        {
            Debug.Log("0`2‚Ì’l‚ğİ’è‚µ‚Ä‚­‚¾‚³‚¢");
        }

        _actionImage.gameObject.SetActive(true);
        StartCoroutine(nameof(DisplayTime));
    }

    IEnumerator DisplayTime()
    {
        yield return new WaitForSeconds(_displayTime);
        _actionImage?.gameObject.SetActive(false);
    }
}
