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
        [SerializeField] private Button settings;
        [SerializeField] private CanvasGroup settingsPanelPrefab;
        [SerializeField] private CanvasGroup storePanelPrefab;
        private CanvasGroup _settingsPanel;
        private CanvasGroup _storePanel;
        private PanelState _panelState;
        private GameDelegates.OnStart _onStart;
        private GameDelegates.ShopOpenClose _shopOpenClose;

        private void Start()
        {
  //          _settingsPanel = Instantiate(settingsPanelPrefab, transform);
//            _storePanel = Instantiate(storePanelPrefab, transform);
            _panelState = new PanelState();
            
            play.onClick.AddListener(OnPlay);
            store.onClick.AddListener(OnStore);
 //           settings.onClick.AddListener(OnSettings);
        }

        private void OnSettings() => _panelState.SetPanel(_settingsPanel);

        private void OnStore()
        {
          //  _panelState.SetPanel(_storePanel); 
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
        }

        public void Unsubscribe(params Delegate[] unsubscribers)
        {
            EventExtensions.Unsubscribe(ref _onStart, unsubscribers);
            EventExtensions.Unsubscribe(ref _shopOpenClose, unsubscribers);
        }
    }
}