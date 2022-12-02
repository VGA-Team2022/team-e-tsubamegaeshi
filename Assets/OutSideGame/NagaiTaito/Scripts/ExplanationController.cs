using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplanationController : MonoBehaviour
{
    [SerializeField] private Sprite[] _images;
    [SerializeField] private Image _image;
    [SerializeField] GameObject _setumei;
    bool _panel = false;
    int _count = 0;
    private void Start()
    {
        _image.sprite = _images[0];
        _panel = _setumei.GetComponent<GameObject>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            _count++;
            _image.sprite = _images[_count % _images.Length];
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _count--;
            if(_count < 0)
            {
                _count = _images.Length - 1;
            }
            _image.sprite = _images[_count % _images.Length];
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (_panel == false)
            {
                _panel = true;
            }
            else if (_panel == true)
            {
                _panel = false;
            }
        }
    }

    //public void PanelTrue()
    //{
    //    if(_panel == false)
    //    {
    //        _panel = true;
    //    }
    //    else if(_panel == true)
    //    {
    //        _panel = false;
    //    }
    //}
}
