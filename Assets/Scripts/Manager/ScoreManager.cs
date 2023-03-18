using System;
using System.Linq;
using UnityEngine;

namespace OUCC.MusicGame.Manager
{
    public class ScoreManager
    {
        public static ScoreManager Instance = new();

        private int _musicId;

        private MusicInfoContainer _container;

        public int TotalScore { get; private set; }

        public int MaxCombo { get; private set; }

        public int CurrentScore { get; private set; }

        public int CurrentComboCount
        {
            get => _currentComboCount;
            private set
            {
                if (MaxCombo < value)
                    MaxCombo = value;
                _currentComboCount = value;
            }
        }
        private int _currentComboCount;

        public NoteEntity[] Initialize()
        {
            var path = string.Empty;
            //TODO
            _container = JsonUtility.FromJson<MusicInfoContainer>(null);
            CurrentScore = 0;
            TotalScore = _container.Notes.Length * CalculateScore(Grade.Perfect);

            return _container.Notes;
        }

        public void Reset()
        {
            _musicId = -1;
            _container = null;
            CurrentScore = -1;
            TotalScore = -1;
            MaxCombo = -1;
            CurrentComboCount = -1;
        }

        /// <summary>
        /// 入力を受けた結果を返します
        /// 引数のtimeはミリ秒単位
        /// </summary>
        public (int Id, Grade)[] OnTap(LanePosition lane, int time)
        {
            // TODO
            return default;
        }

        public Grade OnMiss(int noteId)
        {
            _container.Notes.First(n => n.Id == noteId).Grade = Grade.Miss;
            return Grade.Miss;
        }

        public int RecalculateCurrentScore()
        {
            CurrentScore = _container.Notes.Select(n => CalculateScore(n.Grade)).Sum();
            return CurrentScore;
        }

        private int CalculateScore(Grade grade)
        {
            return grade switch
            {
                Grade.None => 0,
                Grade.Perfect => 100,
                Grade.Great => 80,
                Grade.Good => 50,
                Grade.Bad => 20,
                Grade.Miss => 0,
                _ => throw new NotImplementedException()
            };
        }
    }
}
