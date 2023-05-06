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

        [SerializeField, InspectorOnly]
        private TextMeshProUGUI _gradeResultText;

        private PlayerInput _playerInput;

        private NoteObject[] _noteObjects;

        private void Start()
        {
            _playerInput = GetComponent<PlayerInput>();
            LoadNotes();

            _gradeResultText.text = "";
            _playerInput.onActionTriggered += OnMainInput;
        }

        private void OnDestroy()
        {
            _playerInput.onActionTriggered -= OnMainInput;
            foreach (var note in _noteObjects)
            {
                note.Controller.NoteMiss -= ControllerNoteMiss;
            }
        }

        /// <summary>
        /// ノーツを取得し、配置します
        /// </summary>
        public void LoadNotes()
        {
            NoteOrigin.GetComponent<NoteContoroler>().NoteVelocity = ConfigManager.Instance.Speed;

            var notes = ScoreManager.Instance.Initialize();

            _noteObjects = new NoteObject[notes.Length];
            for (var i = 0; i < notes.Length; i++)
            {
                var noteObj = Instantiate(NoteOrigin, CalculateNotePosition(notes[i]), Quaternion.identity);
                _noteObjects[i] = new NoteObject(notes[i].Id, noteObj);
                _noteObjects[i].Controller.NoteMiss += ControllerNoteMiss;
            }
        }

        /// <summary>
        /// 失敗したeventを受け取ります
        /// </summary>
        private void ControllerNoteMiss(int noteId)
        {
            ScoreManager.Instance.OnMiss(noteId);
            UpdateText();
            var controller = _noteObjects.First(n => n.NoteId == noteId).Controller;
            controller.NoteMiss -= ControllerNoteMiss;
            controller.NoteDestroy();
        }

        /// <summary>
        /// レーンの位置を取得します
        /// </summary>
        private Vector3 CalculateNotePosition(NoteEntity note)
        {
            switch (note.Type)
            {
                case NoteType.Normal:
                    var lane = note.LanePosition switch
                    {
                        LanePosition.LeftLeft => _lanePoint.NoteLanePoint[0],
                        LanePosition.LeftMid => _lanePoint.NoteLanePoint[1],
                        LanePosition.LeftRight => _lanePoint.NoteLanePoint[2],
                        LanePosition.RightLeft => _lanePoint.NoteLanePoint[3],
                        LanePosition.RightMid => _lanePoint.NoteLanePoint[4],
                        LanePosition.RightRight => _lanePoint.NoteLanePoint[5],
                        _ => throw new NotSupportedException(),
                    };
                    lane.z += ConfigManager.Instance.Speed * 1000 * note.StartTime;
                    return lane;
                default:
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        /// スコテキストとコンボテキストを更新します
        /// </summary>
        public void UpdateText()
        {
            _scoreText.text = ScoreManager.Instance.CurrentScore.ToString().PadLeft(8, ' ');
            _comboText.text = ScoreManager.Instance.CurrentComboCount.ToString();
        }

        /// <summary>
        /// 評価を表示します
        /// </summary>
        public void UpdateGradeText(Grade grade)
        {
            switch (grade)
            {
                case Grade.None:
                    _gradeResultText.text = "";
                    break;
                case Grade.Perfect:
                    _gradeResultText.text = "Perfect";
                    break;
                case Grade.Great:
                    _gradeResultText.text = "Great";
                    break;
                case Grade.Good:
                    _gradeResultText.text = "Good";
                    break;
                case Grade.Bad:
                    _gradeResultText.text = "Bad";
                    break;
                case Grade.Miss:
                    _gradeResultText.text = "Miss";
                    break;
            }
        }

        /// <summary>
        /// 再生を開始します
        /// </summary>
        public void StartPlay()
        {
            // 音楽がそもそもないので未実装
            throw new NotSupportedException();
        }

        /// <summary>
        /// キーインプットを受け取ります
        /// </summary>
        private void OnMainInput(InputAction.CallbackContext context)
        {
            LanePosition lanePosition;
            switch (context.action.name)
            {
                case "Left1":
                    lanePosition = LanePosition.LeftLeft;
                    break;
                case "Left2":
                    lanePosition = LanePosition.LeftMid;
                    break;
                case "MidLeft":
                    lanePosition = LanePosition.LeftRight;
                    break;
                case "MidRight":
                    lanePosition = LanePosition.RightLeft;
                    break;
                case "Right2":
                    lanePosition = LanePosition.RightMid;
                    break;
                case "Right1":
                    lanePosition = LanePosition.RightRight;
                    break;
                default:
                    return;
            }

            var (id, grade) = ScoreManager.Instance.OnTap(lanePosition, 1);

            var note = _noteObjects.First(x => x.NoteId == id);

            note.Controller.NoteDestroy();
            note.Controller.NoteMiss -= ControllerNoteMiss;
            UpdateGradeText(grade);
            UpdateText();
        }
    }
}
