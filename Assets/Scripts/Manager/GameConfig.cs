#nullable enable
using System;

namespace OUCC.MusicGame.Manager
{
    [Serializable]
    public class GameConfig
    {
        /// <summary>
        /// 用意している音楽
        /// </summary>
        public MusicEntity[] Musics = Array.Empty<MusicEntity>();
    }
}
