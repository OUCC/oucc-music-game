using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

namespace OUCC.MusicGame
{
    public class SpeedSelect : MonoBehaviour
    {
        //速度表示
        [SerializeField] private TextMeshProUGUI SpeedText;
        //速度
        private double Speed = 1.0;

        //初期の速度表示
        void Start()
        {
            SpeedText.text = Speed.ToString("F");
        }

        //rightArrowキーを押した時速度を0.1上げる
        public void OnSpeedUp(InputAction.CallbackContext context)
        {
            // 離された瞬間でPerformedとなる
            if (!context.performed) return;

            Speed += 0.1;
            SpeedText.text = Speed.ToString("F");

        }
        //rightArrowキーを押した時速度を0.1上げる
        public void OnSpeeDown(InputAction.CallbackContext context)
        {
            // 離された瞬間でPerformedとなる
            if (!context.performed) return;

            Speed -= 0.1;
            SpeedText.text = Speed.ToString("F");

        }
    }
}