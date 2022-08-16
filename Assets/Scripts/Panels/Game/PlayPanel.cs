using System;
using Base;
using CorePlugin.Cross.Events.Interface;
using UnityEngine;

namespace Panels.Game
{
    public class PlayPanel : MonoBehaviour, IEventSubscriber
    {
        [SerializeField] private Joystick joystick;
        private Joystick GetJoystick() => joystick;
        public Delegate[] GetSubscribers()
        {
            return new Delegate[]
            {
                (PanelsGeter.GetJoystick)GetJoystick,
            };
        }
        
    }
}