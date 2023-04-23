using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

namespace OUCC.MusicGame
{
    [RequireComponent(typeof(PlayerInput))]
    public class SpeedSelect : MonoBehaviour
    {
        //速度表示
        [SerializeField] private TextMeshProUGUI SpeedText;
        //速度
        private double Speed = 1.0;

        private PlayerInput _playerInput;

        private void Awake()
        {
            //PlayerInputのインスタンスを取得
            _playerInput = GetComponent<PlayerInput>();
        }
        private void OnEnable()
        {
            if (_playerInput == null) return;

            // デリゲート登録
            _playerInput.onActionTriggered += OnSpeedUp;
            _playerInput.onActionTriggered += OnSpeedDown;
        }

        private void OnDisable()
        {
            if (_playerInput == null) return;

            // デリゲート登録解除
            _playerInput.onActionTriggered -= OnSpeedUp;
            _playerInput.onActionTriggered -= OnSpeedDown;
        }


        //初期の速度表示
        void Start()
        {
            SpeedText.text = Speed.ToString("F");
        }

        //rightArrowキーを押した時速度を0.1上げる
        public void OnSpeedUp(InputAction.CallbackContext context)
        {

            // SpeedUp以外は処理しない
            if (context.action.name != "SpeedUp") return;

            //押された瞬間に動作
            if (!context.started) return;

            Speed += 0.1;
            SpeedText.text = Speed.ToString("F");

        }
        //rightArrowキーを押した時速度を0.1上げる
        public void OnSpeedDown(InputAction.CallbackContext context)
        {
            if (Speed >= 0.1)
            {
                // SpeedDown以外は処理しない
                if (context.action.name != "SpeedDown") return;

                //押された瞬間に動作
                if (!context.started) return;

                Speed -= 0.1;
                SpeedText.text = Speed.ToString("F");
            }

        }
    }
}