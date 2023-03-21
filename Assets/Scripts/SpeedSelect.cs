using UnityEngine;
using TMPro;

namespace OUCC.MusicGame
{
    public class SpeedSelect : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI SpeedText;
        private double Speed = 1.0;
        // Start is called before the first frame update
        void Start()
        {
            SpeedText.text =  Speed.ToString("F"); 
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyUp(KeyCode.RightArrow))
            {
                Speed += 0.1;
                SpeedText.text =  Speed.ToString("F");
            }

            if(Input.GetKeyUp(KeyCode.LeftArrow))
            {
                Speed -= 0.1;
                SpeedText.text =  Speed.ToString("F");
            }

        
        }
    }
}
