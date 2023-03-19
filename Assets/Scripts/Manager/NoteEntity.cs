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
        Left1,

        /// <summary>
        /// 左から2番目
        /// </summary>
        Left2,

        /// <summary>
        /// 真ん中の左側
        /// </summary>
        MidLeft,

        /// <summary>
        /// 真ん中の右側
        /// </summary>
        MidRight,

        /// <summary>
        /// 右から2番目
        /// </summary>
        Right2,

        /// <summary>
        /// 一番右
        /// </summary>
        Right1,
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
