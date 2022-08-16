using System;
using Base;
using CorePlugin.Core;
using CorePlugin.Cross.Events.Interface;
using CorePlugin.Extensions;

namespace Panels.Main
{
    public class StorePanel : PanelBase, IEventHandler
    {
        private MainDelegates.GoToPlay goToPlay;
        protected override void Start()
        {
            EventInitializer.AddHandler(this);
            base.Start();
        }

        protected override void OnClose() => goToPlay?.Invoke();

        public void InvokeEvents()
        {
            
        }

        public void Subscribe(params Delegate[] subscribers)
        {
            EventExtensions.Subscribe(ref goToPlay, subscribers);
        }

        public void Unsubscribe(params Delegate[] unsubscribers)
        {
            EventExtensions.Unsubscribe(ref goToPlay, unsubscribers);
        }
    }
}
