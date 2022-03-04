namespace Dypsloom.RhythmTimeline.Effects
{
    using Dypsloom.RhythmTimeline.Core;
    using Dypsloom.RhythmTimeline.Core.Input;
    using Dypsloom.RhythmTimeline.Scoring;
    using Dypsloom.Shared;
    using UnityEngine;
    using UnityEngine.Events;

    public class ScoreEventReceiver : MonoBehaviour
    {
        [Tooltip("The threshold for a supper chain (ignore if < 0).")]
        [SerializeField] private int m_SuperChainThreshold = -1;
        [Tooltip("The threshold for a supper score (ignore if < 0).")]
        [SerializeField] private float m_SuperScoreThreshold = -1;
        [Tooltip("The threshold for a supper chain percentage (ignore if < 0).")]
        [SerializeField] private float m_SuperChainPercentageThreshold = -1;
        [Tooltip("The threshold for a supper score percentage (ignore if < 0).")]
        [SerializeField] private float m_SuperScorePercentageThreshold = -1;
        
        [Tooltip("Event when the chain breaks.")]
        [SerializeField] protected UnityEvent m_OnBreakChain;
        [Tooltip("Event when the chain increases.")]
        [SerializeField] protected UnityEvent m_OnContinueChain;
        [Tooltip("Event when the score updates.")]
        [SerializeField] protected UnityEvent m_OnScoreChange;
        [Tooltip("Event when the super chain threshold is passed.")]
        [SerializeField] protected UnityEvent m_OnSuperChain;
        [Tooltip("Event when the super score threshold is passed.")]
        [SerializeField] protected UnityEvent m_OnSuperScore;

        protected ScoreManager m_ScoreManager;
        private bool m_SuperChain = false;
        private bool m_SuperScore = false;
    
        private void Start()
        {
            if (m_ScoreManager == null) {
                m_ScoreManager = Toolbox.Get<ScoreManager>();
            }

            m_ScoreManager.OnBreakChain += HandleBreakChain;
            m_ScoreManager.OnContinueChain += HandleContinueChain;
            m_ScoreManager.OnScoreChange += HandleScoreChange;
        }

        private void HandleBreakChain()
        {
            m_OnBreakChain.Invoke();
            m_SuperChain = false;
            m_SuperScore = false;
        }
        
        private void HandleContinueChain(int chain)
        {
            m_OnContinueChain.Invoke();
            
            if(m_SuperChain){ return; }
            
            if (m_SuperChainThreshold > 0) {
                if (chain >= m_SuperChainThreshold) {
                    SuperChain();
                }
            }
            
            if (m_SuperChainPercentageThreshold > 0) {
                if (m_ScoreManager.GetChainPercentage() >= m_SuperChainPercentageThreshold) {
                    SuperChain();
                }
            }
            
        }

        protected virtual void SuperChain()
        {
            m_OnSuperChain.Invoke();
            m_SuperChain = true;
        }

        private void HandleScoreChange(float score)
        {
            m_OnScoreChange.Invoke();
            
            if(m_SuperScore){ return; }
            
            if (m_SuperScoreThreshold > 0) {
                if (score >= m_SuperScoreThreshold) {
                    SuperScore();
                }
            }
            
            if (m_SuperScorePercentageThreshold > 0) {
                if (m_ScoreManager.GetScorePercentage() >= m_SuperScorePercentageThreshold) {
                    SuperScore();
                }
            }
        }
        
        protected virtual void SuperScore()
        {
            m_OnSuperScore.Invoke();
            m_SuperScore = true;
        }
    }
}