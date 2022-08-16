using System;
using CorePlugin.Cross.Events.Interface;
using UnityEngine;

namespace Base.GirlTheEnd
{
    public class FlyableGirl : MonoBehaviour, IEventSubscriber
    {
        private Transform GetEndTransform() => transform;

        public Delegate[] GetSubscribers()
        {
            return new Delegate[]
            {
                (PlayerDelegates.GetEndPoint)GetEndTransform
            };
        }
    }
}
