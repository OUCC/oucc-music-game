using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace OUCC.MusicGame
{
    public class SpeedSelect : MonoBehaviour
    {
        public TextMeshProUGUI speedText;
        private double speed = 1.0;
        // Start is called before the first frame update
        void Start()
        {
            speedText = GetComponent<TextMeshProUGUI>();
            speedText.text =  speed.ToString("F");
        
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyUp(KeyCode.RightArrow)){
                speed += 0.1;
                speedText.text =  speed.ToString("F");
            }

             if(Input.GetKeyUp(KeyCode.LeftArrow)){
                speed -= 0.1;
                speedText.text =  speed.ToString("F");
            }

        
        }
    }
}
