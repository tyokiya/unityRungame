using UnityEngine;

/// <summary>
/// 傾きを感知するクラス
/// </summary>
public class GyroInput : MonoBehaviour
{
    Vector3 input_tilt; // 傾きを入れる
    //[SerializeField] Text test_text; // テストキストを入れる変数

    // 傾きの方向
    public enum TiltDirection
    {
        RIGHT,
        LEFT,
        FRONT
    }
    TiltDirection nowTilt = TiltDirection.FRONT;

    void Update()
    {
        // x軸の加速度を取得
        input_tilt.x = Mathf.Asin(Mathf.Clamp(Input.acceleration.x, -1, 1)) * Mathf.Rad2Deg;

        //値に応じて傾き状況を変更
        if(input_tilt.x > 8)        nowTilt = TiltDirection.RIGHT;
        else if(input_tilt.x < 0)   nowTilt = TiltDirection.LEFT;
        else                        nowTilt = TiltDirection.FRONT;

        ////////    下のコメントアウトの部分はテスト用で残している       ////////////////
        //四元数を受け取る
        //Quaternion quaternion = Input.gyro.attitude;
        //オイラー変換
        //input_tilt = quaternion.eulerAngles;


        //Vector3 angle = Vector3.zero;
        //input_tilt.x = Mathf.Asin(Mathf.Clamp(Input.acceleration.x, -1, 1)) * Mathf.Rad2Deg;
        //input_tilt.y = Mathf.Asin(Mathf.Clamp(Input.acceleration.y, -1, 1)) * Mathf.Rad2Deg;
        //input_tilt.z = Mathf.Asin(Mathf.Clamp(Input.acceleration.z, -1, 1)) * Mathf.Rad2Deg;

        //オイラー変換した値を描画(テスト用)
        //{
        //    string s = input_tilt.x.ToString();
        //    string s2 = input_tilt.y.ToString();
        //    string s3 = input_tilt.z.ToString();

        //    test_text.text = s;
        //}
        /////////////////////////////////////////////////////////////////////////////////
    }

    /// <summary>
    /// スマホの傾き方向を返す
    /// </summary>
    /// <returns>傾き方向</returns>
    public TiltDirection GetDifferenceTilt()
    {
        // 中心から傾いた値を返す
        return nowTilt;
    }
}
