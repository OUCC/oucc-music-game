using System;
using System.Linq;
using InspectorOnlyFields;
using OUCC.MusicGame.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace OUCC.MusicGame
{
    public class GameManager : MonoBehaviour
    {
        [InspectorOnly]
        public GameObject NoteOrigin;

        [SerializeField, InspectorOnly]
        private LanePoint _lanePoint;

        [SerializeField, InspectorOnly]
        private TextMeshProUGUI _scoreText;

        [SerializeField, InspectorOnly]
        private TextMeshProUGUI _comboText;

        private PlayerInput _playerInput;

        private NoteObject[] _noteObjects;

        /// <summary>
        /// 1秒あたりに進む速度
        /// </summary>
        private float _speed = 2f;

        private void Start()
        {
            _playerInput = GetComponent<PlayerInput>();
            LoadNotes();

            _playerInput.onActionTriggered += OnMainInput;
        }

        private void OnDestroy()
        {
            _playerInput.onActionTriggered -= OnMainInput;
            foreach(var note in _noteObjects)
            {
                note.Controller.NoteMiss -= ControllerNoteMiss;
            }
        }

        public void LoadNotes()
        {
            NoteOrigin.GetComponent<NoteContoroler>().NoteVelocity = _speed;

            var notes = ScoreManager.Instance.Initialize();

            _noteObjects = new NoteObject[notes.Length];
            for (var i = 0; i < notes.Length; i++)
            {
                var noteObj = Instantiate(NoteOrigin, CalculateNotePosition(notes[i]), Quaternion.identity);
                _noteObjects[i] = new NoteObject(notes[i].Id, noteObj);
                _noteObjects[i].Controller.NoteMiss += ControllerNoteMiss;
            }
        }

        private void ControllerNoteMiss(int noteId)
        {
            ScoreManager.Instance.OnMiss(noteId);
            UpdateText();
            _noteObjects.First(n => n.NoteId == noteId).Controller.NoteDestroy();
        }

        private Vector3 CalculateNotePosition(NoteEntity note)
        {
            switch (note.Type)
            {
                case NoteType.Normal:
                    var lane = note.LanePosition switch
                    {
                        LanePosition.Left1 => _lanePoint.NoteLanePoint[0],
                        LanePosition.Left2 => _lanePoint.NoteLanePoint[1],
                        LanePosition.MidLeft => _lanePoint.NoteLanePoint[2],
                        LanePosition.MidRight => _lanePoint.NoteLanePoint[3],
                        LanePosition.Right2 => _lanePoint.NoteLanePoint[4],
                        LanePosition.Right1 => _lanePoint.NoteLanePoint[5],
                        _ => throw new NotImplementedException(),
                    };
                    lane.z += _speed * 1000 * note.StartTime;
                    return lane;
                default:
                    throw new NotSupportedException();
            }
        }

        public void UpdateText()
        {
            _scoreText.text = ScoreManager.Instance.CurrentScore.ToString().PadLeft(8, ' ');
            _comboText.text = $"{ScoreManager.Instance.CurrentComboCount} Combo";
        }

        public void StartPlay()
        {

        }

        private void OnMainInput(InputAction.CallbackContext context)
        {
            LanePosition lanePosition;
            switch (context.action.name)
            {
                case "Left1":
                    lanePosition = LanePosition.Left1;
                    break;
                case "Left2":
                    lanePosition = LanePosition.Left2;
                    break;
                case "MidLeft":
                    lanePosition = LanePosition.MidLeft;
                    break;
                case "MidRight":
                    lanePosition = LanePosition.MidRight;
                    break;
                case "Right2":
                    lanePosition = LanePosition.Right2;
                    break;
                case "Right1":
                    lanePosition = LanePosition.Right1;
                    break;
                default:
                    return;
            }

            var (id, grade) = ScoreManager.Instance.OnTap(lanePosition, 1);

            var note = _noteObjects.FirstOrDefault(x => x.NoteId == id);

            if (note is null)
                return;

            note.Controller.NoteDestroy();
            note.Controller.NoteMiss -= ControllerNoteMiss;
            UpdateText();
        }
    }
}
