#nullable enable
using System;

namespace OUCC.MusicGame.Manager
{
    [Serializable]
    public class MusicEntity
    {
        /// <summary>
        /// 音楽のId
        /// </summary>
        public int Id;

        /// <summary>
        /// 音楽の表示名
        /// </summary>
        public string Name = string.Empty;

        /// <summary>
        /// ノーツ情報を保存しているパス
        /// </summary>
        public string Path = string.Empty;
    }
}
