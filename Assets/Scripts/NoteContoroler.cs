using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OUCC.MusicGame
{
    public class NoteContoroler : MonoBehaviour
    {
        public float NoteVelocity;//ノーツの移動速度
        public event Action<int> NoteMiss;//ノーツがタップされずにMissになった時に発行されるイベント
        public int NoteID;//ノーツのID

        public float NoteEndTime;//ノーツが動き出してからノーツが消えるまでの時間
        float NoteNowTime;//ノーツが動き出してから現在までの時間
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //ノーツの移動処理
            this.gameObject.transform.position += Vector3.back * NoteVelocity;

            //ノーツが動き出してからの経過時間が一定以上になれば画面から消えたとみなしイベントを発行
            //FixcUpdateにおいた方がいいかも
            NoteNowTime += Time.deltaTime;
            if (NoteNowTime>=NoteEndTime)
            {
                if (NoteMiss != null) NoteMiss(NoteID);
            }
        }
        /// <summary>
        /// ノーツを非表示にする関数
        /// </summary>
        public void NoteDestroy()
        {
            this.gameObject.SetActive(false);
        }
    }
}
