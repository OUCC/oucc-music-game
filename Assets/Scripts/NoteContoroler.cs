using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OUCC.MusicGame
{
    public class NoteContoroler : MonoBehaviour
    {
        /// <summary>
        /// ノーツの移動速度
        /// </summary>
        [NonSerialized]
        public float NoteVelocity;

        /// <summary>
        /// ノーツがタップされずにMissになった時に発行されるイベント
        /// </summary>
        public event Action<int> NoteMiss;

        /// <summary>
        /// ノーツのID
        /// </summary>
        [NonSerialized]
        public int NoteID;

        /// <summary>
        /// ノーツの判定の位置（z座標）
        /// </summary>
        [NonSerialized]
        public float NoteCheck;

        /// <summary>
        /// ノーツがアウトラインをこえてからノーツが消えるまでの時間
        /// </summary>
        [NonSerialized]
        public float NoteEndTime;

        private float _noteNowTime;//ノーツがアウトラインをこえてから現在までの時間
        private MeshRenderer _noteRenderer;//ノーツのRenderer、非表示にする用
        private bool _isNoteEnd;
        // Start is called before the first frame update

        /// <summary>
        /// ノーツを生成時に呼び出してほしい関数
        /// </summary>
        public void NoteSet()
        {
            _noteRenderer = GetComponent<MeshRenderer>();
            _isNoteEnd = false;
        }

        // Update is called once per frame
        void Update()
        {
            //ノーツが見えなくなったら早期リターン
            if (_isNoteEnd) return;
            //ノーツの移動処理
            transform.position += Vector3.back * NoteVelocity * Time.deltaTime;
            //ノーツがレーンを超えてからの経過時間が一定以上になれば画面から消えたとみなしイベントを発行
            if (transform.position.z <= NoteCheck) _noteNowTime += Time.deltaTime;
            if (_noteNowTime >= NoteEndTime)
            {
                if (NoteMiss != null) NoteMiss(NoteID);
            }
        }

        /// <summary>
        /// ノーツを非表示にする関数
        /// </summary>
        public void NoteDestroy()
        {
            _noteRenderer.enabled = false;
            _isNoteEnd = true;
        }
    }
}
