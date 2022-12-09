using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplanationController : MonoBehaviour
{
    [SerializeField] private Sprite[] _images;
    [SerializeField] private Image _image;
    int _count = 0;
    private void Start()
    {
        _image.sprite = _images[0];
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
    }
}
