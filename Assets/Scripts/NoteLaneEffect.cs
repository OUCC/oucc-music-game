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
        const float flashTime = 0.10f;
        const float flashColor = 160f;
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
            laneMeshRenderer.material.DOColor(color * flashColor, flashTime).OnComplete(() =>
            {
                laneMeshRenderer.material.DOColor(color, flashTime);
            });
        }
    }
}
