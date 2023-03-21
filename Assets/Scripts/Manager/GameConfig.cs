#nullable enable
using System;

namespace OUCC.MusicGame.Manager
{
    [Serializable]
    public class GameConfig
    {
        public MusicEntity[] Musics = Array.Empty<MusicEntity>();
    }
}
