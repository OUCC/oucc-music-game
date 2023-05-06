using System;

namespace OUCC.MusicGame.Manager
{
    [Serializable]
    public class NoteEntity
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id;

        /// <summary>
        /// ノーツタイプ
        /// </summary>
        public NoteType Type;

        /// <summary>
        /// レーンの位置
        /// </summary>
        public LanePosition LanePosition;

        /// <summary>
        /// ノーツの開始時間(ミリ秒単位)
        /// </summary>
        public int StartTime;

        /// <summary>
        /// ノーツの終了時間(ミリ秒単位)
        /// </summary>
        public int EndTime;

        /// <summary>
        /// ノーツの終了位置(ロングノーツの場合だけ使用)
        /// </summary>
        public LanePosition EndLanePosition;

        /// <summary>
        /// タッチした結果
        /// </summary>
        [NonSerialized]
        public Grade Grade;
    }

    public enum LanePosition
    {
        /// <summary>
        /// 一番左
        /// </summary>
        LeftLeft,

        /// <summary>
        /// 左から2番目
        /// </summary>
        LeftMid,

        /// <summary>
        /// 真ん中の左側
        /// </summary>
        LeftRight,

        /// <summary>
        /// 真ん中の右側
        /// </summary>
        RightLeft,

        /// <summary>
        /// 右から2番目
        /// </summary>
        RightMid,

        /// <summary>
        /// 一番右
        /// </summary>
        RightRight,
    }

    public enum NoteType
    {
        Normal,
        Long,
    }

    public enum Grade
    {
        /// <summary>
        /// まだ判定されていない状態
        /// </summary>
        None,

        Perfect,
        Great,
        Good,
        Bad,
        Miss,
    }
}
