using UnityEngine;
using TMPro;

namespace OUCC.MusicGame
{
    public class SpeedSelect : MonoBehaviour
    {
        //速度表示
        [SerializeField] private TextMeshProUGUI speedText;
        //速度
        private double speed = 1.0;

        StartControls startControls;

        private void Awake()
        {
            startControls = new StartControls();
            startControls.Enable();
            startControls.Speed.SpeedUp.started += context =>
            {
                speed += 0.1; speedText.text = speed.ToString("F");
            };
            startControls.Speed.SpeedDown.started += context =>
            {
                if (speed >= 0.1)
                {
                    speed -= 0.1; speedText.text = speed.ToString("F");
                }
            };
        }
        //初期の速度表示
        void Start()
        {
            speedText.text = speed.ToString("F");
        }

    }
}