using System;
using Base;
using CorePlugin.Cross.Events.Interface;
using CorePlugin.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Panels.Main
{
    public class PlayPanel : MonoBehaviour, IEventHandler
    {
        [SerializeField] private Button play;
        [SerializeField] private Button store;
        private PanelState _panelState;
        private GameDelegates.OnStart _onStart;
        private GameDelegates.ShopOpenClose _shopOpenClose;
        private MainDelegates.GoToStore _goToStore;

        private void Start()
        {
            _panelState = new PanelState();
            
            play.onClick.AddListener(OnPlay);
            store.onClick.AddListener(OnStore);
        }

        private void OnStore()
        {
            _goToStore?.Invoke();
            _shopOpenClose.Invoke();
        }

        private void OnPlay() => _onStart?.Invoke();

        public void InvokeEvents()
        {
        }

        public void Subscribe(params Delegate[] subscribers)
        {
            EventExtensions.Subscribe(ref _onStart, subscribers);
            EventExtensions.Subscribe(ref _shopOpenClose, subscribers);
            EventExtensions.Subscribe(ref _goToStore, subscribers);
        }

        public void Unsubscribe(params Delegate[] unsubscribers)
        {
            EventExtensions.Unsubscribe(ref _onStart, unsubscribers);
            EventExtensions.Unsubscribe(ref _shopOpenClose, unsubscribers);
            EventExtensions.Unsubscribe(ref _goToStore, unsubscribers);
        }
    }
}