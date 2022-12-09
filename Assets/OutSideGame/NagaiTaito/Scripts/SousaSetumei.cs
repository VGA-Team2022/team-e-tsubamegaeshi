using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SousaSetumei : MonoBehaviour
{
    private Vector2 _firstPsition;
    private Vector2 _nowPsition;

    private string _direction;

    bool isTouch;
    bool isFlick;

    [SerializeField] private Sprite[] _images;
    [SerializeField] private Image _image;
    int _count = 0;

    private void Start()
    {
        _image.sprite = _images[0];
    }

    private void Update()
    {
        if(isFlick)
        {
            Move();
        }
        else
        {
            OnFlick();
        }
    }

    void OnFlick()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            _firstPsition = new(Input.mousePosition.x , Input.mousePosition.y);

            isTouch = true;
        }

        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            if(_direction == "touch")
            {
                Debug.Log("タッチされた");
            }
            isTouch = false;
        }

        if(isTouch)
        {
            _nowPsition = new(Input.mousePosition.x , Input.mousePosition.y);

            GetDirection();
        }
    }

    void GetDirection()
    {
        var _directionX = _nowPsition.x - _firstPsition.x;
        var _directionY = _nowPsition.y - _firstPsition.y;

        if(Mathf.Abs(_directionY) < Mathf.Abs(_directionX))
        {
            if(30 < _directionX)
            {
                _direction = "右";
            }
            else if(-30 < _directionY)
            {
                _direction = "左";
            }
        }
        else
        {
            _direction = "触ってない";
        }

        if(_direction == null || _direction == "触ってない")
        {
            return;
        }
        isTouch = false;
        isFlick = true;
    }

    void Move()
    {
        switch(_direction)
        {
            case "右":
                _count++;
                _image.sprite = _images[_count % _images.Length];
                
                break;

            case "左":
                _count--;
                if (_count < 0)
                {
                    _count = _images.Length - 1;
                }
                _image.sprite = _images[_count % _images.Length];
                break;

            default:
                return;
        }
    }
}
