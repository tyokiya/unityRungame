using System.Collections;
using System.Collections.Generic;
using UnityEngine;

////////////////////////////////////
// プレイヤーのステータスを管理するスクリプト
////////////////////////////////////

public class Status : MonoBehaviour
{
    //プレイヤーの体力
    //int HP = 10;
    //プレイヤーの状態
    public enum situation
    { 
        walk,
        run,
        jump
    }
    situation nowSituation = situation.walk;

    /// <summary>
    /// 3秒後状態を切りかえるコルーチン
    /// </summary>
    /// <returns></returns>
    public IEnumerator ChangeSituation()
    {
        //3秒待機
        yield return new WaitForSeconds(3f);
        Debug.Log("ステータスコルーチン実行");
        //状態を切り替え
        this.nowSituation = situation.run;
    }

    /// <summary>
    /// 現在のプレイヤーの状態を返す
    /// </summary>
    public situation GetNowPlayerSituation()
    {
        return this.nowSituation;
    }

    /// <summary>
    /// 状態を接地状態に応じて更新する
    /// </summary>
    /// <param name="GroundFlg">接地フラグ</param>
    /// <param name="flick">現在の入力状態</param>
    public void SituationUpdate(bool GroundFlg, ScreenInput.FlickDirection flick)
    {
        //ジャンプ状態から地面についた場合ステータスを変更
        if (GroundFlg == true && this.nowSituation == situation.jump) this.nowSituation = situation.run;

        //フリックの状態に応じてステータスを変更
        //プレイヤーが走っている状態のときはジャンプに切り替える
        if (flick == ScreenInput.FlickDirection.UP && this.nowSituation == situation.run) this.nowSituation = situation.jump;
  
    }

   
}
