using UnityEngine;

namespace OUCC.MusicGame
{
    internal class NoteObject
    {
        public NoteObject(int id, GameObject note)
        {
            NoteId = id;
            Object = note;
            Controller = note.GetComponent<NoteContoroler>();
        }

        public readonly int NoteId;

        public readonly GameObject Object;

        public readonly NoteContoroler Controller;
    }
}
