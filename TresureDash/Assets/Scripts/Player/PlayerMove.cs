using UnityEngine;
using static Status;

/// <summary>
/// プレイヤーの移動を管理するクラス
/// </summary>
public class PlayerMove : MonoBehaviour
{
    // インスペクターから設定
    [SerializeField] PlayerManager playerManager;   // プレイヤーマネージャークラス
    [SerializeField] Rigidbody     parentRigidBody; // 親オブジェクトのリジッドボディ
    [SerializeField] Transform     ParentTransform; // 親オブジェクトのトランスフォーム

    // 現在のジャンプ力
    float current_jumpForce = 0;

    // 定数
    // 振り向き角度の定数
    readonly Vector3 frontAngle = Vector3.zero;           // プレイヤーが正面を向いている時の角度
    readonly Vector3 rightAngle = new Vector3(0, 90, 0);  // プレイヤーが右を向いている時の角度
    readonly Vector3 backAngle  = new Vector3(0,180,0);   // プレイヤーが後ろを向いている時の角度
    readonly Vector3 leftAngle  = new Vector3(0, 270, 0); // プレイヤーが左を向いている時の角度
    // ジャンプ力重力の定数
    const float JumpForce      = 0.21f;  // ジャンプ力
    const float Down_JumpForce = 0.004f; // 重力
    // 移動スピードの定数
    const float WalkSpeed     = 0.01f; // 歩き
    const float RunSpeed      = 0.3f;  // 走り
    const float SideMoveSpeed = 0.08f; // 横移動

    void Update()
    {
        // 毎フレームジャンプ力の減少(0以下になることはない)
        if(current_jumpForce > 0)
        {
            current_jumpForce -= Down_JumpForce;
            if(current_jumpForce < 0)
            {
                current_jumpForce = 0;
            }
        }
    }

    /// <summary>
    /// プレイヤーを入力状態に応じて動かす
    /// </summary>
    /// <param name="flick">現在の入力状態</param>
    /// <param name="state">現在のプレイヤーの状態</param>
    /// <param name="direction">現在のプレイヤーの向いてる方向</param>
    /// <param name="tili_direction">前フレームとのスマホの傾きの差</param>
    /// <param name="turnGroundFlg">回転可能な地面の上に立っているかのフラグ</param>
    /// <param name="ply_jumpSound_delegate">ジャンプ音再生のデリゲート</param>
    public void MovePlayerUpdate(ScreenInput.FlickDirection flick, Status.PlayerState state, Status.PlayerDirection direction, GyroInput.TiltDirection tili_direction,
                                 bool turnGroundFlg, SoundController.PlyPlayerSound ply_jumpSound_delegate)
    {
        // ジャンプの入力でジャンプ力を入れる
        if (flick == ScreenInput.FlickDirection.UP && state == Status.PlayerState.Run)
        {
            // 現在のジャンプ力に力を代入
            current_jumpForce = JumpForce;
            // ジャンプ音再生
            ply_jumpSound_delegate();
        }

        // 回転可能な地面の上か歩き常態である時場合での移動処理回転処理
        if (turnGroundFlg || state == PlayerState.Walk 
            || tili_direction == GyroInput.TiltDirection.FRONT)
        {
            // 回転可能な地面の上での移動処理
            // 歩きモーション中の移動処理
            MovePlayer(state, direction);
        }
        else
        {
            // 横移動を含めた移動処理
            MoveSide(direction, tili_direction);
        }
        
        // 現在の向きに合わせてプレイヤーを回転
        RotationPlayer(direction);
    }

    /// <summary>
    /// プレイヤーの移動処理
    /// </summary>
    /// <param name="state">現在のプレイヤーの状態</param>
    /// <param name="direction">現在のプレイヤーの向いてる方向</param>
    void MovePlayer(Status.PlayerState state, Status.PlayerDirection direction)
    {
        if (state == PlayerState.Walk)
        {
            parentRigidBody.MovePosition(new Vector3(ParentTransform.position.x, ParentTransform.position.y, ParentTransform.position.z + WalkSpeed));
        }
        else
        {
            switch (direction)
            {
                case PlayerDirection.Front:
                    parentRigidBody.MovePosition(new Vector3(ParentTransform.position.x,             // x軸
                                                     ParentTransform.position.y + current_jumpForce, // y軸
                                                     ParentTransform.position.z + RunSpeed));        // z軸
                    break;
                case PlayerDirection.Right:
                    parentRigidBody.MovePosition(new Vector3(ParentTransform.position.x + RunSpeed,  // x軸
                                                     ParentTransform.position.y + current_jumpForce, // y軸
                                                     ParentTransform.position.z));                   // z軸
                    break;
                case PlayerDirection.Back:
                    parentRigidBody.MovePosition(new Vector3(ParentTransform.position.x,             // x軸
                                                     ParentTransform.position.y + current_jumpForce, // y軸
                                                     ParentTransform.position.z - RunSpeed));        // z軸
                    break;
                case PlayerDirection.Left:
                    parentRigidBody.MovePosition(new Vector3(ParentTransform.position.x - RunSpeed,  // x軸
                                                     ParentTransform.position.y + current_jumpForce, // y軸
                                                     ParentTransform.position.z));                   // z軸
                    break;
            }
        }
    }

    /// <summary>
    /// スマホの傾きによる横移動処理
    /// </summary>
    /// <param name="direction">現在のプレイヤーの向いてる方向</param>
    /// <param name="tili_direction">スマホの傾き方向</param>
    void MoveSide(PlayerDirection direction, GyroInput.TiltDirection tili_direction)
    {
        // 傾きと向いてる向きから移動処理をだす
        switch (direction)
        {
            case PlayerDirection.Front:
                // 傾きに合わせた横移動
                if (tili_direction == GyroInput.TiltDirection.RIGHT)
                {
                    parentRigidBody.MovePosition(new Vector3(ParentTransform.position.x + SideMoveSpeed, // x軸
                                                     ParentTransform.position.y + current_jumpForce,     // y軸
                                                     ParentTransform.position.z + RunSpeed));            // z軸
                }
                else if(tili_direction == GyroInput.TiltDirection.LEFT)
                {
                    parentRigidBody.MovePosition(new Vector3(ParentTransform.position.x - SideMoveSpeed, // x軸
                                                     ParentTransform.position.y + current_jumpForce,     // y軸
                                                     ParentTransform.position.z + RunSpeed));            // z軸
                }
                break;
            case PlayerDirection.Right:
                if (tili_direction == GyroInput.TiltDirection.RIGHT)
                {
                    parentRigidBody.MovePosition(new Vector3(ParentTransform.position.x + RunSpeed,  // x軸
                                                     ParentTransform.position.y + current_jumpForce, // y軸
                                                     ParentTransform.position.z - SideMoveSpeed));   // z軸
                }
                else if(tili_direction == GyroInput.TiltDirection.LEFT)
                {
                    parentRigidBody.MovePosition(new Vector3(ParentTransform.position.x + RunSpeed,  // x軸
                                                     ParentTransform.position.y + current_jumpForce, // y軸
                                                     ParentTransform.position.z + SideMoveSpeed));   // z軸
                }
                break;
            case PlayerDirection.Back:
                if (tili_direction == GyroInput.TiltDirection.RIGHT)
                {
                    parentRigidBody.MovePosition(new Vector3(ParentTransform.position.x - SideMoveSpeed, // x軸
                                                     ParentTransform.position.y + current_jumpForce,     // y軸
                                                     ParentTransform.position.z - RunSpeed));            // z軸
                }
                else if (tili_direction == GyroInput.TiltDirection.LEFT)
                {
                    parentRigidBody.MovePosition(new Vector3(ParentTransform.position.x + SideMoveSpeed, // x軸
                                                     ParentTransform.position.y + current_jumpForce,     // y軸
                                                     ParentTransform.position.z - RunSpeed));            // z軸
                }
                break;
            case PlayerDirection.Left:
                if (tili_direction == GyroInput.TiltDirection.RIGHT)
                {
                    parentRigidBody.MovePosition(new Vector3(ParentTransform.position.x - RunSpeed,  // x軸
                                                     ParentTransform.position.y + current_jumpForce, // y軸
                                                     ParentTransform.position.z + SideMoveSpeed));   // z軸
                }
                else if (tili_direction == GyroInput.TiltDirection.LEFT)
                {
                    parentRigidBody.MovePosition(new Vector3(ParentTransform.position.x - RunSpeed,  // x軸
                                                     ParentTransform.position.y + current_jumpForce, // y軸
                                                     ParentTransform.position.z - SideMoveSpeed));   // z軸
                }
                break;
        }
    }

    /// <summary>
    /// プレイヤーの向きを回転
    /// </summary>
    /// <param name="direction">プレイヤーの向いてる方向</param>
    void RotationPlayer(Status.PlayerDirection direction)
    {
        // ステータスの向いてる方向に応じて回転
        switch(direction)
        {
            case PlayerDirection.Front:
                //前を向かせる　
                ParentTransform.eulerAngles = frontAngle;
                break;
            case PlayerDirection.Right:
                //右を向かせる　
                ParentTransform.eulerAngles = rightAngle;
                break;
            case PlayerDirection.Back:
                //後を向かせる　
                ParentTransform.eulerAngles = backAngle;
                break;
            case PlayerDirection.Left:
                //左を向かせる　
                ParentTransform.eulerAngles = leftAngle;
                break;
        }
    }

}
