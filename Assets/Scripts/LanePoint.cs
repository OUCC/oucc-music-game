using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OUCC.MusicGame
{
    public class LanePoint : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> _noteLane = new List<GameObject>();
        [NonSerialized]
        public List<Vector3> NoteLanePoint = new List<Vector3>();

        [SerializeField]
        private GameObject _noteCheker;
        [NonSerialized]
        public float NoteChekPoint;//ノーツの判定を行うZ座標
        // Start is called before the first frame update
        void Awake()
        {
            //ノーツを判定する位置の更新
            NoteChekPoint = _noteCheker.transform.position.z;
            //ノーツを生成する位置のリストの更新
            for (int i = 0; i < _noteLane.Count; i++)
            {
                NoteLanePoint.Add(new Vector3(_noteLane[i].transform.position.x, _noteLane[i].transform.position.y, NoteChekPoint));
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
