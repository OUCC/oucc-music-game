using System;
using System.Linq;
using System.Runtime.CompilerServices;
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

        /// <summary>
        /// 状態をリセットします
        /// </summary>
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
        public (int Id, Grade) OnTap(LanePosition lane, int time)
        {
            const int width = 200;
            var maxTime = time + width;
            var minTime = time - width;
            var targetNotes = _container.Notes
                    .Where(n => n.StartTime > minTime && n.StartTime < maxTime && n.LanePosition == lane)
                    .OrderBy(n => n.StartTime > time ? n.StartTime - time : time - n.StartTime)
                    .FirstOrDefault();
            if (targetNotes is null)
            {
                return (-1, Grade.None);
            }
            else
            {
                var diff = targetNotes.StartTime > time ? targetNotes.StartTime - time : time - targetNotes.StartTime;
                var justGrade = diff switch
                {
                    <= 40 => Grade.Perfect,
                    <= 80 => Grade.Great,
                    <= 140 => Grade.Good,
                    _ => Grade.Bad,
                };

                if (justGrade == Grade.Perfect || justGrade == Grade.Great)
                {
                    CurrentComboCount++;
                }
                else
                {
                    CurrentComboCount = 0;
                }

                CurrentScore += CalculateScore(justGrade);
                return (targetNotes.Id, justGrade);
            }
        }

        /// <summary>
        /// ミスをしたときの処理を行います
        /// </summary>
        public Grade OnMiss(int noteId)
        {
            _container.Notes.First(n => n.Id == noteId).Grade = Grade.Miss;
            CurrentComboCount = 0;
            return Grade.Miss;
        }

        /// <summary>
        /// それぞれの Grade の回数を取得します
        /// </summary>
        public (int Perfect, int Great, int Good, int Bad, int Miss) GetGradeCounts()
        {
            var counts = (0, 0, 0, 0, 0);
            foreach (var item in _container.Notes)
            {
                switch (item.Grade)
                {
                    case Grade.Perfect:
                        counts.Item1++;
                        break;
                    case Grade.Great:
                        counts.Item2++;
                        break;
                    case Grade.Good:
                        counts.Item3++;
                        break;
                    case Grade.Bad:
                        counts.Item4++;
                        break;
                    case Grade.Miss:
                        counts.Item5++;
                        break;
                }
            }
            return counts;
        }

        /// <summary>
        /// スコアを再計算します
        /// </summary>
        public int RecalculateCurrentScore()
        {
            CurrentScore = _container.Notes.Select(n => CalculateScore(n.Grade)).Sum();
            return CurrentScore;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
