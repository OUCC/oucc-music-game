﻿using System;
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
        private MeshRenderer _noteRenderer;//ノーツのRenderer、非表示にする用
        bool _isNoteEnd;
        // Start is called before the first frame update
        void Start()
        {

        }
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
            transform.position += Vector3.back * NoteVelocity;
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
