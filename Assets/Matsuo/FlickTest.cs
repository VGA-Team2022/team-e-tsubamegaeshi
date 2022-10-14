using UnityEngine;

public class FlickTest : MonoBehaviour
{

    private Vector3 _touchStartPos;
    private Vector3 _touchEndPos;

    public enum SwipeDirection
    {
        NONE,
        TAP,
        UP,
        RIGHT,
        DOWN,
        LEFT,
    }
    [SerializeField]
    private SwipeDirection _nowSwipe = SwipeDirection.NONE;


    private void Update()
    {
        Flick();
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
                Direction = "Right";
                Debug.Log(Direction);
                ChangeState(SwipeDirection.RIGHT);
            }

            else if (-30 > directionX)
            {
                //左向きにフリック
                Direction = "Left";
                Debug.Log(Direction);
                ChangeState(SwipeDirection.LEFT);
            }
        }

        else if (Mathf.Abs(directionX) < Mathf.Abs(directionY))
        {
            if (30 < directionY)
            {
                //上向きにフリック
                Direction = "Up";
                Debug.Log(Direction);
                ChangeState(SwipeDirection.UP);
            }
            else if (-30 > directionY)
            {
                //下向きのフリック
                Direction = "Down";
                Debug.Log(Direction);
                ChangeState(SwipeDirection.DOWN);
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
    public void ChangeState(SwipeDirection next)
    {
        // 以前の状態を保持
        var prev = _nowSwipe;
        // 次の状態に変更する
        _nowSwipe = next;
        Debug.Log($"エネミーステート変更 {prev} -> {next}");
        switch (_nowSwipe)
        {
            case SwipeDirection.NONE:
                {

                }
                break;
            case SwipeDirection.UP:
                {

                }
                break;
            case SwipeDirection.DOWN:
                {

                }
                break;
            case SwipeDirection.RIGHT:
                {

                }
                break;
            case SwipeDirection.LEFT:
                {

                }
                break;
            case SwipeDirection.TAP:
                {

                }
                break;
        }
    }
}
