using System;
using Base;
using CorePlugin.Core;
using CorePlugin.Cross.Events.Interface;
using CorePlugin.Extensions;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace Panels.Main
{
    public class StorePanel : PanelBase, IEventHandler
    {
        [SerializeField] private Button leftButton;
        [SerializeField] private Button rightButton;
        private MainDelegates.GoToPlay goToPlay;
        private GameDelegates.ShopOpenClose _shopOpenClose;
        private StoreDelegates.ListNextSkin _listNextSkin;
        private StoreDelegates.ListPreviousSkin _listPreviousSkin;

        protected override void Start()
        {
            base.Start();
            leftButton.onClick.AddListener(OnPreviousSkin);
            rightButton.onClick.AddListener(OnNextSkin);
        }

        protected override void OnClose()
        {
            _shopOpenClose.Invoke();
            goToPlay.Invoke();
        }

        private void OnNextSkin() => _listNextSkin.Invoke();
        private void OnPreviousSkin() => _listPreviousSkin.Invoke();
        public void InvokeEvents()
        {

        }

        public void Subscribe(params Delegate[] subscribers)
        {
            EventExtensions.Subscribe(ref goToPlay, subscribers);
            EventExtensions.Subscribe(ref _shopOpenClose, subscribers);
            EventExtensions.Subscribe(ref _listNextSkin, subscribers);
            EventExtensions.Subscribe(ref _listPreviousSkin, subscribers);
        }

        public void Unsubscribe(params Delegate[] unsubscribers)
        {
            EventExtensions.Unsubscribe(ref goToPlay, unsubscribers);
            EventExtensions.Unsubscribe(ref _shopOpenClose, unsubscribers);
            EventExtensions.Unsubscribe(ref _listNextSkin, unsubscribers);
            EventExtensions.Unsubscribe(ref _listPreviousSkin, unsubscribers);
        }
    }
}
