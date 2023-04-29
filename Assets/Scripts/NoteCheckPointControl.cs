using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OUCC.MusicGame
{
    public class NoteCheckPointControl : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem _noteCheckLineParticle;
        // Start is called before the first frame update
        public void Particle()
        {
            _noteCheckLineParticle.Play();
        }
    }
}
