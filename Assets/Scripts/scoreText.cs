using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace OUCC.MusicGame
{
    public class scoreText : MonoBehaviour
    {
        public TextMeshProUGUI perfectText;
        public TextMeshProUGUI greatText;
        public TextMeshProUGUI goodText;
        public TextMeshProUGUI badText;
        public TextMeshProUGUI missText;
        private int perfect = 100;
        private int great = 100;
        private int good = 100;
        private int bad = 100;
        private int miss = 100;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            perfectText = GetComponent<TextMeshProUGUI>();
            greatText = GetComponent<TextMeshProUGUI>();
            goodText = GetComponent<TextMeshProUGUI>();
            badText = GetComponent<TextMeshProUGUI>();
            missText = GetComponent<TextMeshProUGUI>();
            
            perfectText.text = "perfect" + perfect.ToString();
            greatText.text   = "great" + great.ToString();
            goodText.text    = "good" + good.ToString();
            badText.text     = "bad" + bad.ToString();
            missText.text    = "miss" + miss.ToString();
                      
        
        }
    }
}
