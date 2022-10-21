using UnityEngine;
using System.Collections;

public class FlickTest : MonoBehaviour
{

    private Vector3 _touchStartPos;
    private Vector3 _touchEndPos;

    private Vector3 _lineStartPos;
    private Vector3 _lineEndPos;

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
    public FlickState NowSwipe { get => _nowSwipe; set => _nowSwipe = value; }

    [SerializeField]
    float _stateReSetTime = 0.5f;

    [SerializeField]
    float _flickRange = 30f;

    [SerializeField]
    LineRenderer _line;

    [SerializeField]
    Battele _battele;

    private void Update()
    {
        if(_battele.IsBattle)
        {
            if (_nowSwipe == FlickState.NONE)
            {
                Flick();
            }
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
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            _lineStartPos = Camera.main.ScreenToWorldPoint(_touchStartPos);
            _lineEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            _lineStartPos.z = 0;
            _lineEndPos.z = 0;

            //Debug.Log(_lineStartPos);
            //Debug.Log(_lineEndPos);

            if (_nowSwipe == FlickState.NONE)
            {
                _line.enabled = true;

                _line.SetPosition(0, _lineStartPos);
                _line.SetPosition(1, _lineEndPos);
            }

        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            _touchEndPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);

            _lineEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _lineEndPos.z = 0;
            _line.SetPosition(1, _lineEndPos);

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
            if (_flickRange < directionX)
            {
                //右向きにフリック

                ChangeState(FlickState.RIGHT);
            }

            else if (-_flickRange > directionX)
            {
                //左向きにフリック

                ChangeState(FlickState.LEFT);
            }
        }

        else if (Mathf.Abs(directionX) < Mathf.Abs(directionY))
        {
            if (_flickRange < directionY)
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

    /// <summary>
    /// FlickStateリセット処理
    /// </summary>
    /// <returns></returns>
    IEnumerator StateReSet()
    {
        if(_nowSwipe != FlickState.NONE)
        {
            //Debug.Log("StateReSet");
            yield return new WaitForSeconds(_stateReSetTime);
            _line.enabled = false;
            ChangeState(FlickState.NONE);
        }
    }
}
