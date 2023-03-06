using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace OUCC.MusicGame
{
    public class GameManager : MonoBehaviour
    {
        public GameObject OriginalNote;

        public LanePoint LanePoint;

        private GameObject[] _notes;

        private void Start()
        {

        }

        public void LoadNotes()
        {
            var velocity = 1f;
            var lanes = LanePoint.NoteLanePoint;
            var notesInfo = new NoteMock[0];
            _notes = notesInfo.Select(n =>
            {
                var noteObj = Instantiate(OriginalNote, CalculatePosition(velocity, n.timing, lanes[n.Lane]), Quaternion.identity);
                var nc = noteObj.GetComponent<NoteContoroler>();
                nc.NoteID = n.Id;
                nc.NoteVelocity = velocity;
                return noteObj;
            }).ToArray();
        }

        public void StartPlay()
        {

        }

        public Vector3 CalculatePosition(float velocity, float timing, Vector3 lane)
        {
            lane.x += velocity * timing;
            return lane;
        }
    }
}
