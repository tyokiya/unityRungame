using System;

public class EventList
{
    // 先行入力状態を知らせる
    public Action OnBufferedInputFlg;
    // 先行入力状態を切る
    public Action OffBufferedInputFlg;
}
