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
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //ノーツの移動処理
            this.gameObject.transform.position += Vector3.back * NoteVelocity;
            //ノーツのz座標が一定以上になれば画面から消えたとみなしイベントを発行
            if (this.gameObject.transform.position.z < -1f)
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
