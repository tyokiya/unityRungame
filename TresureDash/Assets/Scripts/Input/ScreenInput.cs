using UnityEngine;

/// <summary>
/// タップ入力を感知するクラス
/// </summary>
public class ScreenInput : MonoBehaviour
{
    readonly Vector2 FlickMinRange = new Vector2(30.0f, 30.0f); // フリックの最小移動距離
    readonly Vector2 SwipeMinRange = new Vector2(50.0f, 50.0f); // スワイプ最小移動距離

    const int NoneCountMax = 2; // TAPをNONEに戻すまでのカウント
    int nowNoneCount = 0;

    Vector2 SwipeRange; // スワイプの入力距離

    // 入力方向記録用
    Vector2 InputSTART;
    Vector2 InputMOVE;
    Vector2 InputEND;
    public enum FlickDirection
    {
        NONE,  // 入力なし
        TAP,   // タップ
        UP,    // 上
        RIGHT, // 右
        DOWN,  // 下
        LEFT,  // 左
    }
    FlickDirection NowFlick = FlickDirection.NONE; // フリックの方向   
    public enum SwipeDirection
    {
        NONE,  // 入力なし
        TAP,   // タップ
        UP,    // 上
        RIGHT, // 右
        DOWN,  // 下
        LEFT,  // 左
    }
    SwipeDirection NowSwipe = SwipeDirection.NONE; // スワイプの方向

    public enum BufferedFlick
    {
        None,  // 入力なし
        RIGHT, // 右
        LEFT,  // 左
    }
    BufferedFlick nowBufferedFlick = BufferedFlick.None; // 先行入力のフリック方向

    // 先行入力ゾーンにいるフラグ
    bool isBufferedInputZone = false;

    // イベントリストの宣言
    EventList eventList = new EventList();

    void Start()
    {
        // イベントリストへのメソッドの追加
        AddEvent();
    }

    void Update()
    {
        GetInputVector();
    }

    void AddEvent()
    {
        eventList.OnBufferedInputFlg  += OnBufferedInputFlg;  // 先行入力フラグを立てるイベント
        eventList.OffBufferedInputFlg += OffBufferedInputFlg; // 先行入力フラグを下ろすイベント
    }

    /// <summary>
    /// 入力の取得
    /// </summary>
    void GetInputVector()
    {
        // Unity上での操作取得
        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                InputSTART = Input.mousePosition;
            }
            else if (Input.GetMouseButton(0))
            {
                InputMOVE = Input.mousePosition;
                SwipeCLC();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                InputEND = Input.mousePosition;
                FlickCLC();
            }
            else if (NowFlick != FlickDirection.NONE || NowSwipe != SwipeDirection.NONE)
            {
                ResetParameter();
            }
        }
        // 端末上での操作取得
        else
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.touches[0];
                if (touch.phase == TouchPhase.Began)
                {
                    InputSTART = touch.position;
                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    InputMOVE = Input.mousePosition;
                    SwipeCLC();
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    InputEND = touch.position;
                    FlickCLC();
                }
            }
            else if (NowFlick != FlickDirection.NONE || NowSwipe != SwipeDirection.NONE)
            {
                ResetParameter();
            }
        }

        // 先行入力の更新
        if(isBufferedInputZone)
        {
            if(NowFlick == FlickDirection.RIGHT)
            {
                nowBufferedFlick = BufferedFlick.RIGHT;
                Debug.Log("先行入力[右]");
            }
            else if(NowFlick == FlickDirection.LEFT)
            {
                nowBufferedFlick = BufferedFlick.LEFT;
                Debug.Log("先行入力[左]");
            }
        }
    }

    /// <summary>
    /// 入力内容からフリック方向を計算
    /// </summary>
    void FlickCLC()
    {
        Vector2 _work = new Vector2((new Vector3(InputEND.x, 0, 0) - new Vector3(InputSTART.x, 0, 0)).magnitude, (new Vector3(0, InputEND.y, 0) - new Vector3(0, InputSTART.y, 0)).magnitude);

        if (_work.x <= FlickMinRange.x && _work.y <= FlickMinRange.y)
        {
            NowFlick = FlickDirection.TAP;
        }
        else if (_work.x > _work.y)
        {
            float _x = Mathf.Sign(InputEND.x - InputSTART.x);
            if (_x > 0)      NowFlick = FlickDirection.RIGHT;
            else if (_x < 0) NowFlick = FlickDirection.LEFT;
        }
        else
        {
            float _y = Mathf.Sign(InputEND.y - InputSTART.y);
            if (_y > 0)      NowFlick = FlickDirection.UP;
            else if (_y < 0) NowFlick = FlickDirection.DOWN;
        }
    }

    /// <summary>
    /// 入力内容からスワイプ方向を計算
    /// </summary>
    void SwipeCLC()
    {
        SwipeRange = new Vector2((new Vector3(InputMOVE.x, 0, 0) - new Vector3(InputSTART.x, 0, 0)).magnitude, (new Vector3(0, InputMOVE.y, 0) - new Vector3(0, InputSTART.y, 0)).magnitude);

        if (SwipeRange.x <= SwipeMinRange.x && SwipeRange.y <= SwipeMinRange.y)
        {
            NowSwipe = SwipeDirection.TAP;
        }
        else if (SwipeRange.x > SwipeRange.y)
        {
            float _x = Mathf.Sign(InputMOVE.x - InputSTART.x);
            if (_x > 0)      NowSwipe = SwipeDirection.RIGHT;
            else if (_x < 0) NowSwipe = SwipeDirection.LEFT;
        }
        else
        {
            float _y = Mathf.Sign(InputMOVE.y - InputSTART.y);
            if (_y > 0)      NowSwipe = SwipeDirection.UP;
            else if (_y < 0) NowSwipe = SwipeDirection.DOWN;
        }
    }

    /// <summary>
    /// NONEにリセット
    /// </summary>
    void ResetParameter()
    {
        nowNoneCount++;
        if (nowNoneCount >= NoneCountMax)
        {
            nowNoneCount = 0;
            NowFlick = FlickDirection.NONE;
            NowSwipe = SwipeDirection.NONE;
            SwipeRange = new Vector2(0, 0);
        }
    }

    /// <summary>
    /// フリック方向の取得
    /// </summary>
    public FlickDirection GetNowFlick()
    {
        return NowFlick;
    }

    /// <summary>
    /// スワイプ方向の取得
    /// </summary>
    public SwipeDirection GetNowSwipe()
    {
        return NowSwipe;
    }

    /// <summary>
    /// 先行入力状態の取得
    /// </summary>
    /// <returns></returns>
    public BufferedFlick GetNowBufferedFLick()
    {
        return nowBufferedFlick;
    }

    /// <summary>
    /// スワイプ量の取得
    /// </summary>
    public float GetSwipeRange()
    {
        if (SwipeRange.x > SwipeRange.y)
        {
            return SwipeRange.x;
        }
        else
        {
            return SwipeRange.y;
        }
    }

    /// <summary>
    /// スワイプ量の取得
    /// </summary>
    public Vector2 GetSwipeRangeVec()
    {
        if (NowSwipe != SwipeDirection.NONE)
        {
            return new Vector2(InputMOVE.x - InputSTART.x, InputMOVE.y - InputSTART.y);
        }
        else
        {
            return new Vector2(0, 0);
        }
    }

    /// <summary>
    /// イベントリストの取得
    /// </summary>
    public EventList GetEventList()
    {
        return eventList;
    }

    /// <summary>
    /// 先行入力ゾーンのフラグを立てる
    /// </summary>
    public void OnBufferedInputFlg()
    {
        isBufferedInputZone = true;
        Debug.Log("先行入力状態の変更");
    }

    /// <summary>
    /// 先行入力ゾーンのフラグを下ろす
    /// </summary>
    public void OffBufferedInputFlg()
    {
        isBufferedInputZone = false;
        Debug.Log("非先行入力状態の変更");
        nowBufferedFlick = BufferedFlick.None; // 先行入力なしに切り替え
    }
}
