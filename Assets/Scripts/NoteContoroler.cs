using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OUCC.MusicGame
{
    public class NoteContoroler : MonoBehaviour
    {
        [NonSerialized]
        public float NoteVelocity;//ノーツの移動速度               
        public event Action<int> NoteMiss;//ノーツがタップされずにMissになった時に発行されるイベント
        [NonSerialized]
        public int NoteID;//ノーツのID
        [NonSerialized]
        public float NoteCheck;//ノーツの判定の位置（z座標）
        [NonSerialized]
        public float NoteEndTime;//ノーツがアウトラインをこえてからノーツが消えるまでの時間
        private float _noteNowTime;//ノーツがアウトラインをこえてから現在までの時間
        private Transform _noteTransform;//ノーツのTransform、キャッシュしておく、しなくてもいいかも？
        private MeshRenderer _noteRenderer;//ノーツのRenderer、非表示にする用
        // Start is called before the first frame update
        void Start()
        {

        }
        /// <summary>
        /// ノーツを生成時に呼び出してほしい関数
        /// </summary>
        public void NoteSet()
        {
            _noteTransform = GetComponent<Transform>();
            _noteRenderer = GetComponent<MeshRenderer>();
        }
        // Update is called once per frame
        void Update()
        {
            //ノーツの移動処理
            _noteTransform.position += Vector3.back * NoteVelocity;
            //ノーツがレーンを超えてからの経過時間が一定以上になれば画面から消えたとみなしイベントを発行
            if (_noteTransform.position.z <= NoteCheck) _noteNowTime += Time.deltaTime;
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
            this.enabled = false;
        }
    }
}
