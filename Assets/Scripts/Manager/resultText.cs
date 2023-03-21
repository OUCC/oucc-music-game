using System;
using UnityEngine;
using TMPro;

namespace OUCC.MusicGame.Manager
{
    public class ResultText : MonoBehaviour
    {
        //スコア表示
        [SerializeField] private TextMeshProUGUI ScoreText;

        //コンボ表示
        [SerializeField] private TextMeshProUGUI ComboText;

        //ランク表示
        [SerializeField] private TextMeshProUGUI RankText;

        //判定表示
        [SerializeField] private TextMeshProUGUI PerfectText;
        [SerializeField] private TextMeshProUGUI GreatText;
        [SerializeField] private TextMeshProUGUI GoodText;
        [SerializeField] private TextMeshProUGUI BadText;
        [SerializeField] private TextMeshProUGUI MissText;
        
        // Start is called before the first frame update
        void Start()
        {
            var counts = ScoreManager.Instance.GetGradeCounts();
            PerfectText.text = "perfect : " + counts.Perfect.ToString();
            GreatText.text = "great : " + counts.Great.ToString();
            GoodText.text = "good: " + counts.Good.ToString();
            BadText.text = "bad : " + counts.Bad.ToString();
            MissText.text = "miss : " + counts.Miss.ToString();

            
            var currentScore = ScoreManager.Instance.CurrentScore;
            var maxcombo = ScoreManager.Instance.MaxCombo;
            ScoreText.text = "score  : " + currentScore.ToString();
            ComboText.text  = "combo : " + maxcombo.ToString();

        
            string rank = RankJudge();
            RankText.text = rank;
            
        }
        

        //Rankの決定
        public string RankJudge()
        {
            var totalScore = ScoreManager.Instance.TotalScore;
            var currentScore = (float)ScoreManager.Instance.CurrentScore;
            var score_rate = currentScore/totalScore;

            if (score_rate >= 0.9)
            {
                 return "S";
            }
            else if (score_rate >= 0.8)
            {
                return "A";
            }
            else if (score_rate >=0.7)
            {
                return "B";
            }
            else 
            {
                return "C";
            }

        }


    }
}
