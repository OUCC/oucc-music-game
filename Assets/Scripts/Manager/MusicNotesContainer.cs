using System;
using log4net.Util;

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

        public MusicEntity Info;

        public NoteEntity[] Notes;
    }
}
