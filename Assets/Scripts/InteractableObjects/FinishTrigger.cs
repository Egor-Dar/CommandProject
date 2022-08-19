using System;
using CorePlugin.Cross.Events.Interface;
using CorePlugin.Extensions;
using Player;
using UnityEngine;

namespace Base.InteractableObjects
{
    public class FinishTrigger : MonoBehaviour, IEventHandler
    {
        private GameDelegates.OnStart _onStart;
        private PlayerDelegates.EndLevel _endLevel;
        private void OnTriggerEnter(Collider other)
        {
            if(!other.gameObject.TryGetComponent(out IInteractable player)) return;
            _onStart.Invoke();
            _endLevel.Invoke();
        }
        public void InvokeEvents()
        {
            
        }
        public void Subscribe(params Delegate[] subscribers)
        {
            EventExtensions.Subscribe(ref _onStart, subscribers);
            EventExtensions.Subscribe(ref _endLevel, subscribers);
        }
        public void Unsubscribe(params Delegate[] unsubscribers)
        {
            EventExtensions.Unsubscribe(ref _onStart, unsubscribers);
            EventExtensions.Unsubscribe(ref _endLevel, unsubscribers);
        }
    }
}
