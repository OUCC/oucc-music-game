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

        /// <summary>
        /// ノーツID
        /// </summary>
        public readonly int NoteId;

        /// <summary>
        /// ノーツのオブジェクト
        /// </summary>
        public readonly GameObject Object;

        /// <summary>
        /// ノーツのコントローラー
        /// </summary>
        public readonly NoteContoroler Controller;
    }
}
