using UnityEngine;
using System.Collections;

public class FlickTest : MonoBehaviour
{

    private Vector3 _touchStartPos;
    private Vector3 _touchEndPos;

    public enum FlickState
    {
        NONE,
        TAP,
        UP,
        RIGHT,
        DOWN,
        LEFT,
    }
    [SerializeField]
    private FlickState _nowSwipe = FlickState.NONE;

    [SerializeField]
    LineRenderer _line;

    private void Start()
    {
        //_imageObj = Instantiate(_imageObj);
        //_imageObj.SetActive(false);
    }

    private void Update()
    {
        if (_nowSwipe == FlickState.NONE)
        {
            Flick();
        }

    }

    /// <summary>
    /// フリック入力受付
    /// </summary>
    void Flick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _touchStartPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);

            //_imageObj.SetActive(true);
            //_imageObj.transform.Rotate(Vector3.zero);
            //var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition + Camera.main.transform.forward * 10);
            //_imageObj.transform.position = pos;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {

            //Vector3 toDirection = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z) - _imageObj.transform.position;
            //// 対象物へ回転する
            //_imageObj.transform.rotation = Quaternion.FromToRotation(Vector3.up, toDirection);
            _line.SetPosition(0, Camera.main.ScreenToWorldPoint(_touchStartPos));
            _line.SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition));


        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _touchEndPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            GetDirection();
        }
    }

    /// <summary>
    /// フリック方向判定
    /// </summary>
    void GetDirection()
    {
        float directionX = _touchEndPos.x - _touchStartPos.x;
        float directionY = _touchEndPos.y - _touchStartPos.y;
        string Direction;

        if (Mathf.Abs(directionY) < Mathf.Abs(directionX))
        {
            if (30 < directionX)
            {
                //右向きにフリック

                ChangeState(FlickState.RIGHT);
            }

            else if (-30 > directionX)
            {
                //左向きにフリック

                ChangeState(FlickState.LEFT);
            }
        }

        else if (Mathf.Abs(directionX) < Mathf.Abs(directionY))
        {
            if (30 < directionY)
            {
                //上向きにフリック

                ChangeState(FlickState.UP);
            }
            else if (-30 > directionY)
            {
                //下向きのフリック

                ChangeState(FlickState.DOWN);
            }
        }
        else
        {
            //タッチを検出
            Direction = "touch";
            Debug.Log(Direction);
        }


    }

    /// <summary>
    /// 状態変更時に1回だけ呼ばれる処理
    /// </summary>
    /// <param name="next"></param>
    public void ChangeState(FlickState next)
    {
        // 以前の状態を保持
        var prev = _nowSwipe;
        // 次の状態に変更する
        _nowSwipe = next;
        Debug.Log($"フリック方向 {prev} -> {next}");
        switch (_nowSwipe)
        {
            case FlickState.NONE:
                {

                }
                break;
            case FlickState.UP:
                {
                    StartCoroutine(StateReSet());

                }
                break;
            case FlickState.DOWN:
                {
                    StartCoroutine(StateReSet());

                }
                break;
            case FlickState.RIGHT:
                {
                    StartCoroutine(StateReSet());

                }
                break;
            case FlickState.LEFT:
                {
                    StartCoroutine(StateReSet());

                }
                break;
            case FlickState.TAP:
                {
                    StartCoroutine(StateReSet());

                }
                break;
        }
    }

    IEnumerator StateReSet()
    {
        if(_nowSwipe != FlickState.NONE)
        {
            //Debug.Log("StateReSet");
            yield return new WaitForSeconds(1);
            //_imageObj.SetActive(false);
            ChangeState(FlickState.NONE);
        }
    }
}
