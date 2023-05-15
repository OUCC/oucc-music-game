using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

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

        // Update is called once per frame
        void Update()
        {
            var keyboard = Keyboard.current;
            if (keyboard != null)
            {
                //　スペースキーの状態の取得
                if (keyboard.spaceKey.wasPressedThisFrame)LaneFlash();
                if (keyboard.spaceKey.wasReleasedThisFrame) Debug.Log("SpaceKey:Up");
            }
        }
        public void LaneFlash()
        {
            laneMeshRenderer.material.SetColor("_EmissionColor",new Color(0,1,0));
        }
    }
}
