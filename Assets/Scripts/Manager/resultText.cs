using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace OUCC.MusicGame.Manager
{
    public class resultText : MonoBehaviour
    {
        ScoreManager scoreManager = new ScoreManager();
        
        public TextMeshProUGUI scoreText , comboText , perfectText , greatText , goodText , badText , missText , rankText;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {

            var Counts = scoreManager.GetGradeCounts();
            perfectText.text = "perfect : " + Counts.Item1.ToString();
            greatText.text = "great : " + Counts.Item2.ToString();
            goodText.text = "good: " + Counts.Item3.ToString();
            badText.text = "bad : " + Counts.Item4.ToString();
            missText.text = "miss : " + Counts.Item5.ToString();

            
            int currentScore = scoreManager.CurrentScore;
            int maxcombo = scoreManager.MaxCombo;
            scoreText.text = "score  : " + currentScore.ToString();
            comboText.text  = "combo : " + maxcombo.ToString();

        
            string Rank = RankJudge();
            rankText.text = Rank;
        
        }

        //Rankの決定
        public string RankJudge()
        {
            int totalScore = scoreManager.TotalScore;
            int currentScore = scoreManager.CurrentScore;
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
