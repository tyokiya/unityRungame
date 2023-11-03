using UnityEngine;
using static Status;

/// <summary>
/// プレイヤーの移動を管理するクラス
/// </summary>
public class Move : MonoBehaviour
{
    // インスペクターから設定
    [SerializeField] PlayerManager playerManager_object;
    [SerializeField] Rigidbody     rd;
    [SerializeField] Transform     parent_transform;

    [Tooltip("プレイヤーが正面を向いている時の角度")]
    Vector3 frontAngle = Vector3.zero;
    [Tooltip("プレイヤーが右を向いている時の角度")]
    Vector3 rightAngle = new Vector3(0, 90, 0);
    [Tooltip("プレイヤーが後ろを向いている時の角度")]
    Vector3 backAngle  = new Vector3(0,180,0);
    [Tooltip("プレイヤーが左を向いている時の角度")]
    Vector3 leftAngle  = new Vector3(0, 270, 0);

    // 現在のジャンプ力
    float current_jumpForce = 0;

    // ジャンプ力重力の定数
    const float JumpForce      = 0.21f;
    const float Down_JumpForce = 0.004f;
    
    // 移動スピードの定数
    const float WalkSpeed     = 0.01f;
    const float RunSpeed      = 0.3f;
    const float SideMoveSpeed = 0.08f;

    void Update()
    {
        // 毎フレームジャンプ力の減少(0以下になることはない)
        if(this.current_jumpForce > 0)
        {
            this.current_jumpForce -= Down_JumpForce;
            if(this.current_jumpForce < 0)
            {
                this.current_jumpForce = 0;
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
                                 bool turnGroundFlg, SoundController.ply_playerSound_delegate ply_jumpSound_delegate)
    {
        // ジャンプの入力でジャンプ力を入れる
        if (flick == ScreenInput.FlickDirection.UP && state == Status.PlayerState.Run)
        {
            //現在のジャンプ力に力を代入
            this.current_jumpForce = JumpForce;
            //ジャンプ音再生
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
            this.rd.MovePosition(new Vector3(parent_transform.position.x, parent_transform.position.y, parent_transform.position.z + WalkSpeed));
        }
        else
        {
            switch (direction)
            {
                case PlayerDirection.Front:
                    this.rd.MovePosition(new Vector3(parent_transform.position.x, 
                                                     parent_transform.position.y + this.current_jumpForce, 
                                                     parent_transform.position.z + RunSpeed));
                    break;
                case PlayerDirection.Right:
                    this.rd.MovePosition(new Vector3(parent_transform.position.x + RunSpeed, 
                                                     parent_transform.position.y + this.current_jumpForce,
                                                     parent_transform.position.z));
                    break;
                case PlayerDirection.Back:
                    this.rd.MovePosition(new Vector3(parent_transform.position.x, 
                                                     parent_transform.position.y + this.current_jumpForce, 
                                                     parent_transform.position.z - RunSpeed));
                    break;
                case PlayerDirection.Left:
                    this.rd.MovePosition(new Vector3(parent_transform.position.x - RunSpeed,
                                                     parent_transform.position.y + this.current_jumpForce,
                                                     parent_transform.position.z));
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
                    this.rd.MovePosition(new Vector3(parent_transform.position.x + SideMoveSpeed,
                                                     parent_transform.position.y + this.current_jumpForce,
                                                     parent_transform.position.z + RunSpeed));
                }
                else if(tili_direction == GyroInput.TiltDirection.LEFT)
                {
                    this.rd.MovePosition(new Vector3(parent_transform.position.x - SideMoveSpeed, 
                                                     parent_transform.position.y + this.current_jumpForce, 
                                                     parent_transform.position.z + RunSpeed));
                }
                break;
            case PlayerDirection.Right:
                if (tili_direction == GyroInput.TiltDirection.RIGHT)
                {
                    this.rd.MovePosition(new Vector3(parent_transform.position.x + RunSpeed,
                                                     parent_transform.position.y + this.current_jumpForce,
                                                     parent_transform.position.z - SideMoveSpeed));
                }
                else if(tili_direction == GyroInput.TiltDirection.LEFT)
                {
                    this.rd.MovePosition(new Vector3(parent_transform.position.x + RunSpeed,
                                                     parent_transform.position.y + this.current_jumpForce,
                                                     parent_transform.position.z + SideMoveSpeed));
                }
                break;
            case PlayerDirection.Back:
                if (tili_direction == GyroInput.TiltDirection.RIGHT)
                {
                    this.rd.MovePosition(new Vector3(parent_transform.position.x - SideMoveSpeed,
                                                     parent_transform.position.y + this.current_jumpForce,
                                                     parent_transform.position.z - RunSpeed));
                }
                else if (tili_direction == GyroInput.TiltDirection.LEFT)
                {
                    this.rd.MovePosition(new Vector3(parent_transform.position.x + SideMoveSpeed,
                                                     parent_transform.position.y + this.current_jumpForce,
                                                     parent_transform.position.z - RunSpeed));
                }
                break;
            case PlayerDirection.Left:
                if (tili_direction == GyroInput.TiltDirection.RIGHT)
                {
                    this.rd.MovePosition(new Vector3(parent_transform.position.x - RunSpeed,
                                                     parent_transform.position.y + this.current_jumpForce,
                                                     parent_transform.position.z + SideMoveSpeed));
                }
                else if (tili_direction == GyroInput.TiltDirection.LEFT)
                {
                    this.rd.MovePosition(new Vector3(parent_transform.position.x - RunSpeed,
                                                     parent_transform.position.y + this.current_jumpForce, 
                                                     parent_transform.position.z - SideMoveSpeed));
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
                this.parent_transform.eulerAngles = this.frontAngle;
                break;
            case PlayerDirection.Right:
                //右を向かせる　
                this.parent_transform.eulerAngles = this.rightAngle;
                break;
            case PlayerDirection.Back:
                //後を向かせる　
                this.parent_transform.eulerAngles = this.backAngle;
                break;
            case PlayerDirection.Left:
                //左を向かせる　
                this.parent_transform.eulerAngles = this.leftAngle;
                break;
        }
    }

}
