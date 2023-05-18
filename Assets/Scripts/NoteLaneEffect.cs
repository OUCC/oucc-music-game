using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using DG.Tweening;

namespace OUCC.MusicGame
{
    public class NoteLaneEffect : MonoBehaviour
    {
        // Start is called before the first frame update
        MeshRenderer laneMeshRenderer;
        void Start()
        {
            laneMeshRenderer = GetComponent<MeshRenderer>();
            laneMeshRenderer.material.EnableKeyword("_EMISSION");
        }

        /// <summary>
        /// レーンを光らせる関数
        /// </summary>
        public void LaneFlash()
        {
            Color color = laneMeshRenderer.material.color;
            laneMeshRenderer.material.DOColor(color * 160f, 0.10f).OnComplete(() =>
            {
                laneMeshRenderer.material.DOColor(color, 0.10f);
            });
        }
    }
}
