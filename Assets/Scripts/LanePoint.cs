using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OUCC.MusicGame
{
    public class LanePoint : MonoBehaviour
    {
        float NoteMakePoint = 95.0f;//ノーツを生成するZ座標、要調整
        [SerializeField] List<GameObject> NoteLane = new List<GameObject>();
        public List<Vector3> NoteLanePoint = new List<Vector3>();

        [SerializeField] GameObject NoteCheker;
        public float NoteChekPoint;//ノーツの判定を行うZ座標
        // Start is called before the first frame update
        void Awake()
        {
            //ノーツを生成する位置のリストの更新
            for (int i = 0; i < NoteLane.Count; i++)
            {
                NoteLanePoint.Add(new Vector3(NoteLane[i].transform.position.x, NoteLane[i].transform.position.y, NoteMakePoint));
            }
            //ノーツを判定する位置の更新
            NoteChekPoint = NoteCheker.transform.position.z;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
