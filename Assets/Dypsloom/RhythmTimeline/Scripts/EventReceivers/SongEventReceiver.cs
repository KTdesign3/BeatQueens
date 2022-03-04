namespace Dypsloom.RhythmTimeline.Effects
{
    using Dypsloom.RhythmTimeline.Core.Managers;
    using Dypsloom.Shared;
    using UnityEngine;
    using UnityEngine.Events;

    public class SongEventReceiver : MonoBehaviour
    {
        [Tooltip("Event whe the song starts.")]
        [SerializeField] protected UnityEvent m_OnSongStart;
        [Tooltip("Event when the song ends.")]
        [SerializeField] protected UnityEvent m_OnSongEnd;
        [Tooltip("Event when the song is paused.")]
        [SerializeField] protected UnityEvent m_OnSongPause;
        [Tooltip("Event when the song is unpaused.")]
        [SerializeField] protected UnityEvent m_OnSongUnPause;

        protected RhythmDirector m_RhythmDirector;

        private void Start()
        {
            if (m_RhythmDirector == null) { m_RhythmDirector = Toolbox.Get<RhythmDirector>(); }

            m_RhythmDirector.OnSongPlay += HandleOnSongPlay;
            m_RhythmDirector.OnSongEnd += HandleOnSongEnd;
            m_RhythmDirector.OnSongPause += HandleOnSongPause;
            m_RhythmDirector.OnSongUnPause += HandleOnSongUnPause;
        }

        private void HandleOnSongPlay()
        {
            m_OnSongStart.Invoke();
        }
        
        private void HandleOnSongEnd()
        {
            m_OnSongEnd.Invoke();
        }

        private void HandleOnSongPause()
        {
            m_OnSongPause.Invoke();
        }

        private void HandleOnSongUnPause()
        {
            m_OnSongUnPause.Invoke();
        }
    }
}