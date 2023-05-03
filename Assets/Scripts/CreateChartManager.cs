using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OUCC.MusicGame.InputSystem;
using OUCC.MusicGame.Manager;
using UnityEngine.InputSystem;

namespace OUCC.MusicGame
{
    [RequireComponent(typeof(AudioSource))]
    public sealed class CreateChartManager : MonoBehaviour
    {
        private MainControls _mainControls;

        private AudioSource _audioSource;

        private MusicEntity _musicEntity;

        private List<NoteEntity> _notes = new(256);

        private void Awake()
        {
            _mainControls = new();
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            _mainControls.Lane.Left1.performed += context => OnCreateChart(context, LanePosition.Left1);
        }

        private void OnCreateChart(InputAction.CallbackContext context, LanePosition lanePosition)
        {
            var newNote = new NoteEntity()
            {
                LanePosition = lanePosition,
                StartTime = (int)(_audioSource.time * 1000),
            };
            _notes.Add(newNote);
        }

        private void Save()
        {

        }

        private void Load()
        {

        }
    }
}
