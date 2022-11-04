using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionOnDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject _actionImage; // UŒ‚‚Ì‰æ‘œ

    [SerializeField]
    private float _displayTime = 1f; // ‰æ‘œ‚Ì•\¦ŠÔ

    private void Start()
    {
        //_actionImage = GetComponent<SpriteRenderer>();
        _actionImage.gameObject.SetActive(false);
    }

    public void OnDisplay(Color color)
    {
        //_actionImage.color = color;
        _actionImage.gameObject.SetActive(true);
        StartCoroutine(nameof(DisplayTime));
    }

    IEnumerator DisplayTime()
    {
        yield return new WaitForSeconds(_displayTime);
        _actionImage?.gameObject.SetActive(false);
    }
}
