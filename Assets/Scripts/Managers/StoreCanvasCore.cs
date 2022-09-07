using System;
using Base;
using CorePlugin.Core;
using CorePlugin.Cross.Events.Interface;
using CorePlugin.Extensions;
using Panels;
using UnityEngine;

namespace Managers
{
    public class StoreCanvasCore : BaseCore, IEventSubscriber, IEventHandler
    {
        [SerializeField] private CanvasGroup storePrefab;
        [SerializeField] private Transform canvas;
        private CanvasGroup _store;
        private PanelState _statePanel;
        private MainDelegates.GetPanelState _getPanelState;
            
        private void Awake()
        {
            _store = Instantiate(storePrefab, canvas);
        }
        private void Start()
        {
            _statePanel = _getPanelState.Invoke();
        }
        private void GoToStore()
        {
            _statePanel.SetPanel(_store);
        }
        public Delegate[] GetSubscribers()
        {
            return new Delegate[]
            {
                (MainDelegates.GoToStore)GoToStore
            };

        }
        public void InvokeEvents()
        {
            
        }
        public void Subscribe(params Delegate[] subscribers)
        {
            EventExtensions.Subscribe(ref _getPanelState, subscribers);
        }
        public void Unsubscribe(params Delegate[] unsubscribers)
        {
            EventExtensions.Unsubscribe(ref _getPanelState, unsubscribers);
        }
    }
}
