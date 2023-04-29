using System;

namespace OUCC.MusicGame.Manager
{
    [Serializable]
    public class MusicNotesContainer
    {
        public static readonly MusicNotesContainer Empty = new()
        {
            Info = new() { Id = -1, Name = "", Path = "" },
            Notes = Array.Empty<NoteEntity>()
        };

        /// <summary>
        /// 現在選択している音楽の情報
        /// </summary>
        public MusicEntity Info;

        /// <summary>
        /// 現在選択している音楽のノーツ
        /// </summary>
        public NoteEntity[] Notes;
    }
}
