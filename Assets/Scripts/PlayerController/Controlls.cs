using System;
using Base;
using CorePlugin.Cross.Events.Interface;
using CorePlugin.Extensions;
using UnityEngine;

namespace PlayerController
{
    public class Controlls : MonoBehaviour, IEventHandler
    {
        private PanelsGeter.GetJoystick joystick;
        private PlayerDelegates.Movement movement;

        private void Start()
        {
            joystick.Invoke();
        }

        private void FixedUpdate()
        {
            movement?.Invoke(-joystick.Invoke().Direction.x);
        }

        public void InvokeEvents()
        {
            
        }

        public void Subscribe(params Delegate[] subscribers)
        {
            EventExtensions.Subscribe(ref joystick, subscribers);
            EventExtensions.Subscribe(ref movement, subscribers);
        }

        public void Unsubscribe(params Delegate[] unsubscribers)
        {
            EventExtensions.Unsubscribe(ref movement,unsubscribers);
            EventExtensions.Unsubscribe(ref joystick,unsubscribers);
        }
    }
}