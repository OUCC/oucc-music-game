using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OUCC.MusicGame
{
    public class Music1 : MonoBehaviour
    {
        // Start is called before the first frame update
        public void OnClick()
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
