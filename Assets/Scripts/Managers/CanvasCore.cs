using System;
using Base;
using CorePlugin.Core;
using CorePlugin.Cross.Events.Interface;
using Panels;
using UnityEngine;

namespace Managers
{
    public class CanvasCore : BaseCore, IEventSubscriber
    {
        [SerializeField] private CanvasGroup playPrefab;
        [SerializeField] private CanvasGroup mainPrefab;
        private CanvasGroup _play;
        private CanvasGroup _main;
        private PanelState statePanel;
        private PanelState GetPanelState() => statePanel;

        private void Awake()
        {
            statePanel = new PanelState();
            _play = Instantiate(playPrefab, transform);
            _main = Instantiate(mainPrefab, transform);
            GoToMain();
        }

        private void GoToPlay()
        {
            statePanel.SetPanel(_play);
        }

        private void GoToMain()
        {
            statePanel.SetPanel(_main);
        }

        public Delegate[] GetSubscribers()
        {
            return new Delegate[]
            {
                (GameDelegates.OnStart)GoToPlay,
                (MainDelegates.GetPanelState) GetPanelState,
                (MainDelegates.GoToPlay)GoToMain
            };
        }
    }
}
