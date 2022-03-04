/// ---------------------------------------------
/// Rhythm Timeline
/// Copyright (c) Dyplsoom. All Rights Reserved.
/// https://www.dypsloom.com
/// ---------------------------------------------
/*
namespace Dypsloom.RhythmTimeline.UI
{
    using Dypsloom.RhythmTimeline.Core.Managers;
    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class SongChooserPanel : SongChooserPanelKS
    {

        
        [Tooltip("The song button prefab.")]
        [SerializeField] protected SongButton m_SongButtonPrefab;
        [Tooltip("The scroll bar.")]
        [SerializeField] protected ScrollRect m_ScrollRect;
        [Tooltip("The scroll view content.")]
        [SerializeField] protected RectTransform m_ScrollViewContent;
        [Tooltip("The selected song panel.")]
        [SerializeField] protected SelectedSongPanel m_SelectedSongPanel;
        

        protected List<SongButton> m_ButtonsList;
        protected RhythmGameManager m_RhythmGameManagerKSCustomScript;
        protected int m_SelectedIndex;
        protected bool m_IsOpen;
        protected bool m_Populated = false;
        protected float m_ViewHeight;
        protected float m_ButtonHeight;
        
        public int SelectedIndex => m_SelectedIndex;
        public bool IsOpen => m_IsOpen;

        

        public RhythmGameManager RhythmGameManager => m_RhythmGameManagerKSCustomScript;

        public void Open(RhythmGameManager gameManager)
        {
            m_IsOpen = true;
            m_RhythmGameManagerKSCustomScript = gameManager;
            PopulateScrollView();
            m_SelectedSongPanel.Open(this);
            m_SelectedSongPanel.SetSelectedSong(m_RhythmGameManagerKSCustomScript.Songs[m_SelectedIndex]);
            gameObject.SetActive(true);
        }
        
    
       
    }
}

*/




